using MetaExcel2Code.Config;

namespace MetaExcel2Code.Excel;

public static class CellParser
{

    public static object Parse(TypeStruct typeStruct, string value)
    {
        if (typeStruct.type == "number")
        {
            if (int.TryParse(value,out int num))
            {
                return num;
            }
            else
            {
                throw new BusinessException(ErrorEnum.SHEET_CELL_PARSE_ERROR, value);
            }
        }
        else if (typeStruct.type == "string")
        {
            return value;
        }
        else if (typeStruct.type =="boolean")
        {
            return bool.Parse(value) ? 1 : 0;
        }
        else if (typeStruct.type == "array")
        {
            if (value.StartsWith('[') && value.EndsWith(']'))
            {
                string inner = value.Substring(1, value.Length - 2);
                string[] parts = inner.Split(",", StringSplitOptions.RemoveEmptyEntries);
                return parts.Select(item => Parse(TypeParser.Parse(item), item)).ToArray();
            }
            else
            {
                throw new BusinessException(ErrorEnum.SHEET_CELL_PARSE_ERROR_ARRAY, value);
            }
        }
        else
        {
            throw new BusinessException(ErrorEnum.SHEET_CELL_PARSE_ERROR, value);
        }
    }
    
}