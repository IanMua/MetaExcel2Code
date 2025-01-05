namespace MetaExcel2Code.Excel;

public class CustomType
{
    public required string name { init; get; }
    public required string type { init; get; }

    public CustomType(string name, string type)
    {
        this.name = name;
        this.type = type;
    }
}