namespace MetaExcel2CodeProgram.ExcelPipeLine;

public class SheetStruct
{
    public required List<string> sheetKeys { init; get; }
    public required List<Dictionary<string,object?>> sheetData { init; get; }
}