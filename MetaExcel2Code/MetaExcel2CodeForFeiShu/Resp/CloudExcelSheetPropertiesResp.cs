using MetaExcel2CodeForFeiShu.Models;
using Newtonsoft.Json;

namespace MetaExcel2CodeForFeiShu.Resp;

public class CloudExcelSheetPropertiesResp
{
    [JsonProperty("grid_properties")]
    public required CloudExcelGridPropertiesResp gridPropertiesResp { init; get; }
    
    public required bool hidden { init; get; }
    
    public required int index { init; get; }
    
    [JsonProperty("resource_type")]
    public required string resourceType { init; get; }
    
    [JsonProperty("sheet_id")]
    public required string sheetId { init; get; }
    
    public required string title { init; get; }
}