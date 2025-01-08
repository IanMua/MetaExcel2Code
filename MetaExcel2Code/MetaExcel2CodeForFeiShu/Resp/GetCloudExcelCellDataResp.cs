namespace MetaExcel2CodeForFeiShu.Resp;

public class GetCloudExcelCellDataResp
{
    public required int revision { init; get; }
    public required string spreadsheetToken { init; get; }
    public required int totalCells { init; get; }
    public required List<GetCloudExcelCellValueRangesResp> valueRanges { init; get; }
}