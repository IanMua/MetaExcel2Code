namespace MetaExcel2CodeProgram;

public class AppConfig()
{
    // 日志级别
    public required string logger { init; get; }
    
    // Excel 文件根目录
    public required string excelRootPath { init; get; }
    // Json 导出目录
    public required string jsonExportPath { init; get; }
    // Code 导出目录
    public required string codeExportPath { init; get; }
}