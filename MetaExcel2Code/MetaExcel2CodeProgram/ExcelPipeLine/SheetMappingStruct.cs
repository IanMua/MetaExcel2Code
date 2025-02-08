namespace MetaExcel2CodeProgram.ExcelPipeLine;

public class SheetMappingStruct
{
    public SheetFullStruct sheetFullStruct { get; }
    
    public List<string> mappings { get; }
    
    public List<string> keys { get; }
    
    public List<string> codes { get; }
    
    public SheetMappingStruct(SheetFullStruct sheetFullStruct, List<string> mappings, List<string> keys, List<string> codes)
    {
        this.sheetFullStruct = sheetFullStruct;
        this.mappings = mappings;
        this.keys = keys;
        this.codes = codes;
    }
}