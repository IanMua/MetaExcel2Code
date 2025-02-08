using System.Text;
using MetaExcel2CodeProgram.Models;

namespace MetaExcel2CodeProgram.ExcelPipeLine;

public static class CellParser
{
    public static object? Parse(TypeStruct typeStruct, string? value)
    {
        if (typeStruct.type == "number")
        {
            if (value is null)
            {
                throw new Exception("number 类型不能为空");
            }

            if (double.TryParse(value, out double num))
            {
                return num;
            }

            throw new Exception($"{value} 不是 number 类型");
        }

        if (typeStruct.type == "string")
        {
            return value;
        }

        if (typeStruct.type == "boolean")
        {
            if (value is null)
            {
                throw new Exception("boolean 类型不能为空");
            }

            return bool.Parse(value);
        }

        if (typeStruct is { type: "Array", generic: not null })
        {
            if (value is null)
            {
                throw new Exception("Array 类型不能为空");
            }

            if (value.StartsWith('[') && value.EndsWith(']'))
            {
                string inner = value.Substring(1, value.Length - 2);
                List<string> parts = StringStructParse(inner, '[', ']', ',');
                if (parts.Count == 0) return parts;
                return parts.Select(item => Parse(TypeParser.Parse(typeStruct.generic), item)).ToArray();
            }

            throw new Exception($"{value} 不是 Array 类型");
        }

        if (typeStruct is { type: "Mapping", generic: not null })
        {
            if (Program.IsMappingType(typeStruct.generic))
            {
                if (value is null)
                {
                    throw new Exception("Mapping 类型不能为空");
                }

                if (typeStruct.generic is null)
                {
                    throw new Exception("Mapping 泛型不能为空");
                }

                MappingType mappingType;
                try
                {
                    mappingType = Program.GetMappingType(typeStruct.generic, value);
                }
                catch
                {
                    throw new Exception($"{value} 不是 {typeStruct.generic} 类型");
                }

                return Parse(TypeParser.Parse(mappingType.type), mappingType.value);
            }

            throw new Exception($"{typeStruct.generic} 不是 Mapping 类型");
        }

        if (Program.IsCustomType(typeStruct.type))
        {
            if (value == null)
            {
                return null;
            }

            if (value.StartsWith('{') & value.EndsWith('}'))
            {
                string inner = value.Substring(1, value.Length - 2);
                List<string> parts = StringStructParse(inner, '{', '}', ';');

                TypeConfig typeConfig = Program.GetCustomType(typeStruct.type);
                if (typeConfig.types.Count != parts.Count)
                    throw new Exception($"{value} 的长度与 {typeStruct.type} 类型的类型长度不一致");

                Dictionary<string, object?> tempDict = new();
                for (int i = 0; i < parts.Count; i++)
                {
                    object? itemValue = Parse(TypeParser.Parse(typeConfig.types[i].type), parts[i]);
                    tempDict.Add(typeConfig.types[i].name, itemValue);
                }

                return tempDict;
            }

            throw new Exception($"{value} 不是 {typeStruct.type} 类型");
        }

        throw new Exception($"{typeStruct.type} 是未定义的类型");
    }

    private static List<string> StringStructParse(string input, char leftBracket, char rightBracket, char separator)
    {
        var result = new List<string>();
        var stack = new Stack<char>();
        var currentToken = new StringBuilder();

        foreach (char c in input)
        {
            if (c == leftBracket)
            {
                // 遇到左括号：无论栈是否为空，都将其加入 token 并压栈
                currentToken.Append(c);
                stack.Push(c);
            }
            else if (c == rightBracket)
            {
                // 遇到右括号：如果有左括号在栈中，就先出栈（匹配到一对括号）
                if (stack.Count > 0)
                {
                    stack.Pop();
                }

                // 把右括号也加入到当前 token
                currentToken.Append(c);

                // 如果出栈后，栈为空，代表一个完整括号块结束
                // 是否要在这里立刻添加到 result，需要看你想要的切分方式：
                // 如果希望 "A(B)" 这样的块一结束就作为一个独立部分，可以在这儿直接切。
                // 目前的写法是：只在遇到分隔符或最后结尾时，才会把 currentToken 放进 result，
                // 所以这里并不立即将 Token 加入 result。
            }
            else if (c == separator && stack.Count == 0)
            {
                // 当且仅当栈为空，才按分隔符切开
                result.Add(currentToken.ToString());
                currentToken.Clear();
            }
            else
            {
                // 普通字符：直接加到当前 token
                currentToken.Append(c);
            }
        }

        // 循环结束后，如果 currentToken 里有内容，把它加到结果
        if (currentToken.Length > 0)
        {
            result.Add(currentToken.ToString());
        }

        // 如果栈中仍然有没被配对的左括号，可以根据需求处理，这里只简单地打印
        if (stack.Count > 0)
        {
            Console.WriteLine("警告：存在未匹配的左括号！");
        }

        return result;
    }
}