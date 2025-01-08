using MetaExcel2CodeForFeiShu.Resp;

namespace MetaExcel2CodeForFeiShu.Models;

public class CloudExcelSheetData(string name, List<List<string?>> values)
{
    public string name { get; } = name;
    public List<List<string?>> values { get; } = values;
}