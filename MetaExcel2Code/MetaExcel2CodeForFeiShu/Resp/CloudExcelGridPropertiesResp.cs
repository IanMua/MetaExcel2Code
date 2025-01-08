using Newtonsoft.Json;

namespace MetaExcel2CodeForFeiShu.Resp;

public class CloudExcelGridPropertiesResp
{
    [JsonProperty("column_count")]
    public required int columnCount { init; get; }
    
    [JsonProperty("frozen_column_count")]
    public required int frozenColumnCount { init; get; }
    
    [JsonProperty("row_count")]
    public required int rowCount { init; get; }
    
    [JsonProperty("frozen_row_count")]
    public required int frozenRowCount { init; get; }
}