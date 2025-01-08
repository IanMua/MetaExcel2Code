namespace MetaExcel2CodeForFeiShu.Resp;

public class GetCloudExcelCellValueRangesResp
{
    public required string majorDimension { init; get; }
    public required string range  { init; get; }
    public required int revision { init; get; }
    public required List<List<string?>> values { init; get; }
}