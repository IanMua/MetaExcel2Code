namespace MetaExcel2CodeProgram;

public class TypeConfig()
{
    public required string name { init; get; }
    public required List<CustomType> types { init; get; }

    public override string ToString()
    {
        return $"name: {name}, CustomTypes: {types}";
    }
}