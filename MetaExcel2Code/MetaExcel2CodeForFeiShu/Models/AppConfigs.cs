namespace MetaExcel2CodeForFeiShu.Models;

public class AppConfigs
{
    public required string? appId { init; get; }
    public required string? appSecret { init; get; }
    
    public required string? jsonExportPath { init; get; }
    public required string? jsonFileName { init; get; }
    public required string? codeExportPath { init; get; }
    public required string? codeFileName { init; get; }
    
    public required List<CloudExcelUrl>? cloudExcelUrls { init; get; }
    
    public required List<TypeConfig>? typeList { init; get; }
    
    public AppConfigs(string appId, string appSecret, string jsonExportPath, string codeExportPath, List<CloudExcelUrl> cloudExcelUrls, List<TypeConfig> typeList, string? jsonFileName, string? codeFileName)
    {
        this.appId = appId;
        this.appSecret = appSecret;
        this.jsonExportPath = jsonExportPath;
        this.codeExportPath = codeExportPath;
        this.cloudExcelUrls = cloudExcelUrls;
        this.typeList = typeList;
        this.jsonFileName = jsonFileName;
        this.codeFileName = codeFileName;
    }
}