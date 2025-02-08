namespace MetaExcel2CodeForFeiShu.ExcelPipeLine;

public class MappingType
{
    public string type { get; }
    
    public string value { get; }
    
    public MappingType(string type, string value)
    {
        this.type = type;
        this.value = value;
    }
}