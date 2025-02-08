namespace MetaExcel2CodeProgram.Models;

public class StandardExcelSheetData(string name, List<List<string?>> values)
{
    public string name { get; } = name;
    public List<List<string?>> values { get; } = values;
}