using MetaExcel2CodeForFeiShu.Models;

namespace MetaExcel2CodeForFeiShu.Resp;

public class GetCloudExcelDataResp
{
    public required List<CloudExcelSheetPropertiesResp> sheets { init; get; }
}