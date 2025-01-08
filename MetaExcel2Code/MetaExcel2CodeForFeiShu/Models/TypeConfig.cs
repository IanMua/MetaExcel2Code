namespace MetaExcel2CodeForFeiShu.Models;

public class TypeConfig
{
    public required string name { init; get; }
    public required List<CustomType> types { init; get; }

    public TypeConfig(string name, List<CustomType> types)
    {
        this.name = name;
        this.types = types;
    }

    public override string ToString()
    {
        return $"name: {name}, CustomTypes: {types}";
    }
}