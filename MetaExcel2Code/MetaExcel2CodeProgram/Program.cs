using MetaExcel2CodeProgram.ExcelPipeLine;
using Newtonsoft.Json;
using OfficeOpenXml;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace MetaExcel2CodeProgram;

public abstract class Program
{
    private static LoggingLevelSwitch _levelSwitch = null!;

    private static AppConfig _appConfig = null!;

    private static readonly Dictionary<string, TypeConfig> TypeConfigDict = new();

    public static void Main(string[] args)
    {
        _levelSwitch = new LoggingLevelSwitch();

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt")
            .MinimumLevel.ControlledBy(_levelSwitch)
            .CreateLogger();

        try
        {
            Log.Information("应用启动 {Time}", DateTime.Now);

            RunApplication();
        }
        catch (Exception ex)
        {
            Log.Error("Error: {Message}", ex.Message);
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    /** 运行应用 */
    private static void RunApplication()
    {
        string appConfigFilePath =
            "F:/Project/Learn/C#/MetaExcel2Code/MetaExcel2Code/MetaExcel2CodeProgram/Configs/AppConfig.json";
        string typeConfigFilePath =
            "F:/Project/Learn/C#/MetaExcel2Code/MetaExcel2Code/MetaExcel2CodeProgram/Configs/TypeConfig.json";

        if (!File.Exists(appConfigFilePath)) throw new Exception("AppConfig.json 文件不存在");
        string appConfigJsonFile = File.ReadAllText(appConfigFilePath);
        if (string.IsNullOrWhiteSpace(appConfigJsonFile)) throw new Exception("AppConfig.json 文件内容为空");

        // 序列化校验
        try
        {
            _appConfig = JsonConvert.DeserializeObject<AppConfig>(appConfigJsonFile) ?? throw new Exception();
        }
        catch (Exception)
        {
            throw new Exception("AppConfig.json 文件内容错误，无法反序列化");
        }

        //AppConfig 合法性校验
        if (!Directory.Exists(_appConfig.excelRootPath))
        {
            Log.Warning($"AppConfig.json excelRootPath - {_appConfig.excelRootPath} 该目录不存在");

            Directory.CreateDirectory(_appConfig.excelRootPath);
            
            Log.Warning($"AppConfig.json excelRootPath - {_appConfig.excelRootPath} 该目录已创建");
        }

        if (!Directory.Exists(_appConfig.jsonExportPath))
        {
            Log.Warning($"AppConfig.json jsonExportPath - {_appConfig.jsonExportPath} 该目录不存在");
            
            Directory.CreateDirectory(_appConfig.jsonExportPath);
            
            Log.Warning($"AppConfig.json jsonExportPath - {_appConfig.jsonExportPath} 该目录已创建");
        }

        if (!Directory.Exists(_appConfig.codeExportPath))
        {
            Log.Warning($"AppConfig.json codeExportPath - {_appConfig.codeExportPath} 该目录不存在");
            
            Directory.CreateDirectory(_appConfig.codeExportPath);
            
            Log.Warning($"AppConfig.json codeExportPath - {_appConfig.codeExportPath} 该目录已创建");
        }

        // 设置日志级别
        _levelSwitch.MinimumLevel = _appConfig.logger switch
        {
            "info" => LogEventLevel.Information,
            "warning" => LogEventLevel.Warning,
            "error" => LogEventLevel.Error,
            _ => LogEventLevel.Information
        };

        if (File.Exists(typeConfigFilePath))
        {
            string typeConfigJsonFile = File.ReadAllText(typeConfigFilePath);
            if (string.IsNullOrWhiteSpace(typeConfigJsonFile)) throw new Exception("TypeConfig.json 文件内容为空");
            try
            {
                List<TypeConfig>? typeConfigs = JsonConvert.DeserializeObject<List<TypeConfig>>(typeConfigJsonFile);
                if (typeConfigs != null)
                {
                    foreach (TypeConfig typeConfig in typeConfigs)
                    {
                        TypeConfigDict.Add(typeConfig.name, typeConfig);
                    }
                }

                Log.Information("自定义类型 {Value}", JsonConvert.SerializeObject(TypeConfigDict.Keys));
            }
            catch (Exception)
            {
                throw new Exception("TypeConfig.json 文件内容错误，无法反序列化");
            }
        }

        WorkSpacePipe();
    }

    private static void Test()
    {
        string path = @"F:\Project\Work\MGF\SlimeAssemble\Game_SlimeAssemble\SlimeAssemble\ExcelExporter\lzy\测试2.xlsx";

        using ExcelPackage package = new ExcelPackage(new FileInfo(path));
        var worksheet = package.Workbook.Worksheets[0];

        SheetStruct sheetData = SheetParser.Parse(worksheet);
        Log.Information("sheetData: {Value}", JsonConvert.SerializeObject(sheetData));
    }

    /** 工作空间流 */
    private static void WorkSpacePipe()
    {
        string?[] directories = Directory.GetDirectories(_appConfig.excelRootPath);
        if (directories == null || directories.Length == 0) throw new Exception("工作空间为空，请先创建工作空间");
    }

    private static void LoadWorkSpace(string workSpacePath)
    {
        if (!Directory.Exists(workSpacePath)) throw new Exception($"{workSpacePath} 工作空间不存在");
    }

    public static bool IsCustomType(string type)
    {
        return TypeConfigDict.ContainsKey(type);
    }

    public static TypeConfig GetCustomType(string type)
    {
        return TypeConfigDict[type];
    }
}