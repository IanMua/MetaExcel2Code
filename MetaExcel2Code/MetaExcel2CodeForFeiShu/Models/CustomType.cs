namespace MetaExcel2CodeForFeiShu.Models;

public class CustomType
{
    public required string name { init; get; }
    public required string ann { init; get; }
    public required string type { init; get; }

    public CustomType(string name, string ann, string type)
    {
        this.name = name;
        this.ann = ann;
        this.type = type;
    }

    public override string ToString()
    {
        return $"name:{name}, type:{type}";
    }
}