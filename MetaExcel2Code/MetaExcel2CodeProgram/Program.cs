using MetaExcel2CodeProgram.ExcelPipeLine;
using MetaExcel2CodeProgram.Models;
using Newtonsoft.Json;
using OfficeOpenXml;
using Serilog;

namespace MetaExcel2CodeProgram;

public abstract class Program
{
    private static bool _success = true;

    private const string AppConfigsFilename =
        "./AppConfigs.json";

    public static AppConfigs AppConfigs = null!;

    private static readonly Dictionary<string, TypeConfig> TypeConfigDict = [];

    private static Dictionary<string, Dictionary<string, MappingType>> MappingTypeDict = [];

    public static void Main()
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

            RunApplication();
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

            Log.CloseAndFlush();

            Console.ReadKey();
        }
    }

    private static void RunApplication()
    {
        AppConfigsCheck();

        List<StandardExcelSheetData> cloudExcelSheetDataList = GetLocalExcelData();

        // Dictionary<string, SheetMappingStruct> sheetMappingStructs = ParseMappingCloudExcel(cloudExcelSheetDataList);

        var (sheetStructDict, sheetFullStructDict) = ParseLocalExcel(cloudExcelSheetDataList);

        string code = CodeGenerate.GenerateTsCode(sheetFullStructDict, []);

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
    /// 获取本地数据表信息
    /// </summary>
    private static List<StandardExcelSheetData> GetLocalExcelData()
    {
        Log.Information("==============================");
        Log.Information("开始获取本地Excel数据");
        
        // 获取当前工作目录
        string currentDirectory = Directory.GetCurrentDirectory();
        
        // 定义搜索模式，获取所有以 .xlsx 结尾的文件
        string searchPattern = "*.xlsx";
        
        // 获取文件列表并过滤掉以 "~" 开头的文件（Excel 的临时文件）
        string[] excelFiles = Directory.GetFiles(currentDirectory, searchPattern)
            .Where(file => !Path.GetFileName(file).StartsWith("~"))
            .ToArray();
        
        List<StandardExcelSheetData> cloudExcelSheetDataList = [];
        
        // 检查是否找到文件
        if (excelFiles.Length == 0)
        {
            return cloudExcelSheetDataList;
        }

        foreach (string file in excelFiles)
        {
            using ExcelPackage package = new ExcelPackage(new FileInfo(file));
            int maxCount = package.Workbook.Worksheets.Count;
            for (int i = 0; i < maxCount; i++)
            {
                 var worksheet = package.Workbook.Worksheets[i];
                 
                 Log.Information($"sheet表：{worksheet.Name}");
                 
                 List<List<string?>> values = [];
                 
                 for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                 {
                     try
                     {
                         List<string?> rowData = [];
                         for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                         {
                             var cellValue = worksheet.Cells[row, col].Value?.ToString() ?? null;
                             rowData.Add(cellValue);
                         }

                         values.Add(rowData);
                     }
                     catch (Exception ex)
                     {
                         throw new Exception($"sheet表：{worksheet.Name}，第{row}行解析失败：{ex.Message}\n{ex.StackTrace}");
                     }
                 }
                 
                 cloudExcelSheetDataList.Add(new StandardExcelSheetData(worksheet.Name, values));
            }
        }
        
        return cloudExcelSheetDataList;
    }

    /// <summary>
    /// 解析本地数据表
    /// </summary>
    /// <param name="cloudExcelSheetDataList">云数据表</param>
    private static (Dictionary<string, SheetStruct> sheetStructDict, Dictionary<string, SheetFullStruct>
        sheetFullStructDict) ParseLocalExcel(List<StandardExcelSheetData> cloudExcelSheetDataList)
    {
        Log.Information("已获取到所有本地数据表，开始解析");

        // 最终数据字典
        Dictionary<string, SheetStruct> sheetStructDict = [];

        Dictionary<string, SheetFullStruct> sheetFullStructDict = [];

        foreach (StandardExcelSheetData cloudExcelSheetData in cloudExcelSheetDataList)
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