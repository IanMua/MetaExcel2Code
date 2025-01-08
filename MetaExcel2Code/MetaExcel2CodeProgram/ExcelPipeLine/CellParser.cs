namespace MetaExcel2CodeProgram.ExcelPipeLine;

public static class CellParser
{
    public static object Parse(TypeStruct typeStruct, string value)
    {
        if (typeStruct.type == "number")
        {
            if (int.TryParse(value, out int num))
            {
                return num;
            }
            else
            {
                throw new Exception($"{value} 不是 number 类型");
            }
        }

        if (typeStruct.type == "string")
        {
            return value;
        }

        if (typeStruct.type == "boolean")
        {
            return bool.Parse(value) ? 1 : 0;
        }

        if (typeStruct.type == "array" && typeStruct.generic != null)
        {
            if (value.StartsWith('[') && value.EndsWith(']'))
            {
                string inner = value.Substring(1, value.Length - 2);
                string[] parts = inner.Split(',', StringSplitOptions.RemoveEmptyEntries);
                return parts.Select(item => Parse(TypeParser.Parse(typeStruct.generic), item)).ToArray();
            }

            throw new Exception($"{value} 不是 array 类型");
        }

        if (Program.IsCustomType(typeStruct.type))
        {
            if (value.StartsWith('{') & value.EndsWith('}'))
            {
                string inner = value.Substring(1, value.Length - 2);
                string[] parts = inner.Split(';', StringSplitOptions.RemoveEmptyEntries);

                TypeConfig typeConfig = Program.GetCustomType(typeStruct.type);
                if (typeConfig.types.Count != parts.Length)
                    throw new Exception($"{value} 的长度与 {typeStruct.type} 类型的类型长度不一致");

                Dictionary<string, object> tempDict = new();
                for (int i = 0; i < parts.Length; i++)
                {
                    object itemValue = Parse(TypeParser.Parse(typeConfig.types[i].type), parts[i]);
                    tempDict.Add(typeConfig.types[i].name, itemValue);
                }
                return tempDict;
            }

            throw new Exception($"{value} 不是 {typeStruct.type} 类型");
        }

        throw new Exception($"{typeStruct.type} 是未定义的类型");
    }
}