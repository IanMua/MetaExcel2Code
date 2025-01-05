namespace MetaExcel2CodeProgram;

public class CustomType
{
    public required string name { init; get; }
    public required string type { init; get; }

    public override string ToString()
    {
        return $"name:{name}, type:{type}";
    }
}