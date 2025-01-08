namespace MetaExcel2CodeForFeiShu.Resp;

public class GetCloudExcelResp
{
    public required int code { init; get; }
    public required string msg { init; get; }
    public required GetCloudExcelDataResp data { init; get; }
}