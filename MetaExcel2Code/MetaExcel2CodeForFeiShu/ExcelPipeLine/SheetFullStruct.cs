namespace MetaExcel2CodeForFeiShu.ExcelPipeLine;

public class SheetFullStruct
{
    public List<string> fields { get; }

    public List<string> types { get; }

    public List<string?> annotations { get; }

    public SheetStruct sheetStruct { get; }

    public SheetFullStruct(List<string> fields, List<string> types, List<string?> annotations, SheetStruct sheetStruct)
    {
        this.fields = fields;
        this.types = types;
        this.annotations = annotations;
        this.sheetStruct = sheetStruct;
    }
}