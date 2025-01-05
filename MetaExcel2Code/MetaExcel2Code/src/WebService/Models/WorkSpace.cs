namespace MetaExcel2Code.model;

public class WorkSpace
{
    public string name { get; }
    public string path { get; }
    public ExcelInfo[] excelList { get; }

    public WorkSpace(string name,string path, ExcelInfo[] excelList)
    {
        this.name = name;
        this.path = path;
        this.excelList = excelList;
    }
}