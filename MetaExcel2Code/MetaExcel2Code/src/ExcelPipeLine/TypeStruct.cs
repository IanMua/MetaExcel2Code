namespace MetaExcel2Code.Excel;

/** 类型结构 */
public class TypeStruct
{
    // 类型
    public string type { get; }

    // 泛型
    public string? generic { get; }

    // 约束
    public string? constraint { get; }

    public TypeStruct(string type, string? generic = null, string? constraint = null)
    {
        this.type = type;
        this.generic = generic;
        this.constraint = constraint;
    }

    public override string ToString()
    {
        return $"type: {type}, generic: {generic ?? "null"}, constraint: {constraint ?? "null"}";
    }
}