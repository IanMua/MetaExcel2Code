namespace MetaExcel2Code.model;

public class ExcelInfo
{
    public string name { get; }
    public string path { get; }

    public ExcelInfo(string name, string path)
    {
        this.name = name;
        this.path = path;
    }
}