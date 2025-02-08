using System.Net;
using MetaExcel2CodeForFeiShu.ExcelPipeLine;
using MetaExcel2CodeForFeiShu.Models;
using MetaExcel2CodeForFeiShu.Resp;
using MetaExcel2CodeForFeiShu.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Serilog;
using RestRequest = RestSharp.RestRequest;

namespace MetaExcel2CodeForFeiShu;

internal abstract class Program
{
    private static bool _success = true;

    private const string AppConfigsFilename =
        "./AppConfigs.json";

    public static AppConfigs AppConfigs = null!;

    private static string _tenantAccessToken = null!;

    private static readonly Dictionary<string, TypeConfig> TypeConfigDict = [];

    private static Dictionary<string, Dictionary<string, MappingType>> MappingTypeDict = [];

    public static async Task Main()
    {
        const string logFilePath = "log.txt";
        if (File.Exists(logFilePath)) File.Delete(logFilePath);
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(
                "log.txt",
                rollingInterval: RollingInterval.Infinite,
                fileSizeLimitBytes: null,
                rollOnFileSizeLimit: false,
                retainedFileCountLimit: null,
                shared: true
            )
            .MinimumLevel.Information()
            .CreateLogger();

        try
        {
            Log.Information("应用启动 {Time}", DateTime.Now);

            await RunApplication();
        }
        catch (Exception ex)
        {
            _success = false;
            Log.Error("Error: {Message}", $"{ex.Message}\n{ex.StackTrace}");
        }
        finally
        {
            if (_success) Log.Information("文件导出成功！");
            else Log.Error("文件导出失败");

            await Log.CloseAndFlushAsync();

            Console.ReadKey();
        }
    }

    private static async Task RunApplication()
    {
        AppConfigsCheck();

        await GetTenantAccessToken();

        List<CloudExcelSheetData> cloudExcelSheetDataList = await GetCloudExcelData();

        Dictionary<string, SheetMappingStruct> sheetMappingStructs = ParseMappingCloudExcel(cloudExcelSheetDataList);

        var (sheetStructDict, sheetFullStructDict) = ParseCloudExcel(cloudExcelSheetDataList);

        string code = CodeGenerate.GenerateTsCode(sheetFullStructDict, sheetMappingStructs);

        File.WriteAllText($"{AppConfigs.jsonExportPath!}/{AppConfigs.jsonFileName}",
            JsonConvert.SerializeObject(sheetStructDict));
        File.WriteAllText($"{AppConfigs.codeExportPath!}/{AppConfigs.codeFileName}", code);
    }

    /// <summary>
    /// 应用配置检测
    /// </summary>
    private static void AppConfigsCheck()
    {
        Log.Information("开始进行应用配置检测");

        if (!File.Exists(AppConfigsFilename)) throw new Exception("应用配置文件丢失");

        string appConfigsFile = File.ReadAllText(AppConfigsFilename);
        if (string.IsNullOrWhiteSpace(appConfigsFile)) throw new Exception("应用配置文件为空");

        try
        {
            AppConfigs = JsonConvert.DeserializeObject<AppConfigs>(appConfigsFile) ??
                         throw new InvalidOperationException();
        }
        catch (Exception)
        {
            throw new Exception("应用配置文件反序列化失败");
        }

        if (string.IsNullOrWhiteSpace(AppConfigs.jsonExportPath)) throw new Exception("JSON导出目录为空");
        if (!Directory.Exists(AppConfigs.jsonExportPath)) Directory.CreateDirectory(AppConfigs.jsonExportPath);
        if (string.IsNullOrWhiteSpace(AppConfigs.jsonFileName)) throw new Exception("JSON文件名为空");

        if (string.IsNullOrWhiteSpace(AppConfigs.codeExportPath)) throw new Exception("代码导出目录为空");
        if (!Directory.Exists(AppConfigs.codeExportPath)) Directory.CreateDirectory(AppConfigs.codeExportPath);
        if (string.IsNullOrWhiteSpace(AppConfigs.codeFileName)) throw new Exception("代码文件名为空");

        if (string.IsNullOrWhiteSpace(AppConfigs.appId)) throw new Exception("飞书应用ID位空");
        if (string.IsNullOrWhiteSpace(AppConfigs.appSecret)) throw new Exception("飞书应用密钥为空");
        if (AppConfigs.cloudExcelUrls is null) throw new Exception("飞书云数据表配置项为空");

        if (AppConfigs.typeList is null) return;
        foreach (TypeConfig typeConfig in AppConfigs.typeList)
        {
            TypeConfigDict.Add(typeConfig.name, typeConfig);
        }
    }

    /// <summary>
    /// 获取Token
    /// </summary>
    private static async Task GetTenantAccessToken()
    {
        Log.Information("开始获取 TenantAccessToken");

        string url = "https://open.feishu.cn/open-apis/auth/v3/tenant_access_token/internal";

        var client = new RestClient(url);

        var request = new RestRequest("", Method.Post);
        request.AddJsonBody(new { app_id = AppConfigs.appId, app_secret = AppConfigs.appSecret });

        var response = await client.ExecuteAsync(request);

        if (response is { IsSuccessful: true, Content: not null })
        {
            TenantAccessTokenResp tenantAccessTokenResp =
                JsonConvert.DeserializeObject<TenantAccessTokenResp>(response.Content) ??
                throw new InvalidOperationException();
            _tenantAccessToken = tenantAccessTokenResp.tenantAccessToken;
        }
        else
        {
            Log.Error($"StatusCode: {response.StatusCode}");
            Log.Error($"Content: {response.Content}");
            Log.Error($"ErrorMessage: {response.ErrorMessage}");
            throw new Exception("TenantAccessToken 请求或反序列化失败");
        }
    }

    /// <summary>
    /// 获取云数据表信息
    /// </summary>
    private static async Task<List<CloudExcelSheetData>> GetCloudExcelData()
    {
        Log.Information("==============================");
        Log.Information("开始获取云Excel数据");

        var client = new RestClient("https://open.feishu.cn/open-apis/sheets/v3/spreadsheets");

        var tasks = new List<Task<GetCloudExcelResp>>();

        var semaphore = new SemaphoreSlim(3);

        foreach (CloudExcelUrl cloudExcelUrl in AppConfigs.cloudExcelUrls!)
        {
            tasks.Add(Task.Run(async () =>
            {
                await semaphore.WaitAsync();

                try
                {
                    Log.Information($"获取云数据表 {cloudExcelUrl.name} 电子表格信息");

                    var request = new RestRequest(cloudExcelUrl.url + "/sheets/query");
                    request.AddHeader("Authorization", "Bearer " + _tenantAccessToken);

                    while (true)
                    {
                        var response = await client.ExecuteAsync(request);

                        if (response.StatusCode == HttpStatusCode.TooManyRequests)
                        {
                            await Task.Delay(300);
                            continue;
                        }

                        if (response is { IsSuccessful: true, Content: not null })
                        {
                            GetCloudExcelResp? cloudExcelResp;
                            try
                            {
                                cloudExcelResp = JsonConvert.DeserializeObject<GetCloudExcelResp>(response.Content);
                            }
                            catch (Exception ex)
                            {
                                Log.Error($"响应：{response.Content}");
                                Log.Error(ex.Message);
                                throw new Exception($"{cloudExcelUrl.name} 数据表反序列化失败");
                            }

                            if (cloudExcelResp is null)
                            {
                                Log.Error($"响应：{response.Content}");
                                throw new Exception($"{cloudExcelUrl.name} 数据表反序列化失败");
                            }

                            return cloudExcelResp;
                        }

                        Log.Error($"StatusCode: {response.StatusCode}");
                        Log.Error($"Content: {response.Content}");
                        Log.Error($"ErrorMessage: {response.ErrorMessage}");
                        throw new Exception($"{cloudExcelUrl.name} 数据获取失败");
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            }));
        }

        var cloudExcelDataRespList = new List<GetCloudExcelResp>(await Task.WhenAll(tasks));

        Log.Information("==============================");

        List<CloudExcelSheetData> cloudExcelSheetDataList = [];

        var cellTasks = new List<Task<List<CloudExcelSheetData>>>();

        for (var i = 0; i < cloudExcelDataRespList.Count; i++)
        {
            var i1 = i;
            cellTasks.Add(Task.Run(async () =>
            {
                await semaphore.WaitAsync();
                try
                {
                    return await GetCloudExcelCellData(cloudExcelDataRespList[i1].data, AppConfigs.cloudExcelUrls[i1]);
                }
                finally
                {
                    semaphore.Release();
                }
            }));
        }

        var cellResult = await Task.WhenAll(cellTasks);
        foreach (var cellResultItem in cellResult)
        {
            cloudExcelSheetDataList.AddRange(cellResultItem);
        }

        return cloudExcelSheetDataList;
    }

    /// <summary>
    /// 拿到云数据表信息后，获取所有单元格数据
    /// </summary>
    private static async Task<List<CloudExcelSheetData>> GetCloudExcelCellData(
        GetCloudExcelDataResp cloudExcelDataResp,
        CloudExcelUrl cloudExcelUrl
    )
    {
        Log.Information($"开始获取云数据表 {cloudExcelUrl.name} 单元格数据");

        string ranges = string.Join(",",
            cloudExcelDataResp.sheets.Select(sheet =>
                $"{sheet.sheetId}!A1:{ExcelTools.NumberToLetters(sheet.gridPropertiesResp.columnCount)}{sheet.gridPropertiesResp.rowCount}"));

        var client = new RestClient("https://open.feishu.cn/open-apis/sheets/v2/spreadsheets");

        var request = new RestRequest(cloudExcelUrl.url + "/values_batch_get");

        request.AddHeader("Authorization", $"Bearer {_tenantAccessToken}");

        request.AddQueryParameter("ranges", ranges);
        request.AddQueryParameter("valueRenderOption", "FormattedValue");
        request.AddQueryParameter("dateTimeRenderOption", "FormattedString");

        while (true)
        {
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                await Task.Delay(300);
                continue;
            }

            try
            {
                if (response is { IsSuccessful: true, Content: not null })
                {
                    JObject jsonObj = JObject.Parse(response.Content);

                    GetCloudExcelCellDataResp cloudExcelCellDataResp =
                        jsonObj["data"]?.ToObject<GetCloudExcelCellDataResp>() ??
                        throw new Exception($"{cloudExcelUrl.name} 解析数据为空");

                    List<CloudExcelSheetData> cloudExcelSheetDataList = [];
                    for (var i = 0; i < cloudExcelCellDataResp.valueRanges.Count; i++)
                    {
                        cloudExcelSheetDataList.Add(new CloudExcelSheetData(cloudExcelDataResp.sheets[i].title,
                            cloudExcelCellDataResp.valueRanges[i].values));
                    }

                    return cloudExcelSheetDataList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{cloudExcelUrl.name} 单元格数据获取失败 -- ${ex.Message}");
            }


            Log.Error($"StatusCode: {response.StatusCode}");
            Log.Error($"Content: {response.Content}");
            Log.Error($"ErrorMessage: {response.ErrorMessage}");
            throw new Exception($"{cloudExcelUrl.name} 单元格数据获取失败");
        }
    }

    /// <summary>
    /// 解析用于映射的云数据表
    /// </summary>
    /// <param name="cloudExcelSheetDataList">云数据表</param>
    private static Dictionary<string, SheetMappingStruct> ParseMappingCloudExcel(
        List<CloudExcelSheetData> cloudExcelSheetDataList)
    {
        List<CloudExcelSheetData> mappingCloudExcelSheetDataList = [];

        // 获取是用于映射的云数据表
        cloudExcelSheetDataList.ForEach(cloudExcelSheetData =>
        {
            if (cloudExcelSheetData.name.StartsWith('$'))
            {
                mappingCloudExcelSheetDataList.Add(cloudExcelSheetData);
            }
        });

        Dictionary<string, SheetMappingStruct> sheetMappingStructDict = [];
        mappingCloudExcelSheetDataList.ForEach(
            cloudExcelSheetData =>
            {
                SheetMappingStruct sheetMappingStruct = SheetParser.ParseMapping(cloudExcelSheetData);

                Dictionary<string, MappingType> sheetMappingDict = [];
                for (var i = 0; i < sheetMappingStruct.mappings.Count; i++)
                {
                    sheetMappingDict.Add(sheetMappingStruct.mappings[i],
                        new MappingType(sheetMappingStruct.sheetFullStruct.types[0], sheetMappingStruct.keys[i]));
                }
                
                MappingTypeDict.Add(cloudExcelSheetData.name[1..], sheetMappingDict);
                sheetMappingStructDict.Add(cloudExcelSheetData.name[1..], sheetMappingStruct);
            });

        return sheetMappingStructDict;
    }

    /// <summary>
    /// 解析云数据表
    /// </summary>
    /// <param name="cloudExcelSheetDataList">云数据表</param>
    private static (Dictionary<string, SheetStruct> sheetStructDict, Dictionary<string, SheetFullStruct>
        sheetFullStructDict) ParseCloudExcel(List<CloudExcelSheetData> cloudExcelSheetDataList)
    {
        Log.Information("已获取到所有云数据表，开始解析");

        // 最终数据字典
        Dictionary<string, SheetStruct> sheetStructDict = [];

        Dictionary<string, SheetFullStruct> sheetFullStructDict = [];

        foreach (CloudExcelSheetData cloudExcelSheetData in cloudExcelSheetDataList)
        {
            if (cloudExcelSheetData.name.StartsWith('$'))
            {
                continue;
            }

            SheetFullStruct sheetFullStruct = SheetParser.Parse(cloudExcelSheetData);
            sheetStructDict.Add(cloudExcelSheetData.name, sheetFullStruct.sheetStruct);
            sheetFullStructDict.Add(cloudExcelSheetData.name, sheetFullStruct);
        }

        return (sheetStructDict, sheetFullStructDict);
    }

    public static bool IsCustomType(string type)
    {
        return TypeConfigDict.ContainsKey(type);
    }

    public static TypeConfig GetCustomType(string type)
    {
        return TypeConfigDict[type];
    }

    public static bool IsMappingType(string type)
    {
        return MappingTypeDict.ContainsKey(type);
    }

    public static MappingType GetMappingType(string type, string mapping)
    {
        return MappingTypeDict[type][mapping];
    }
}