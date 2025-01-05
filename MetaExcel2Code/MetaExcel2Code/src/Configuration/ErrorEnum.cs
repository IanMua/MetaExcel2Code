namespace MetaExcel2Code.Config;

public enum ErrorEnum
{
    // 成功
    SUCCESS = 200,
    
    // 未知错误
    UNKNOWN_ERROR = 1000,
    
    // excel表类型为空
    SHEET_NULL_TYPE = 2000,
    // excel表类型不符合格式
    SHEET_TYPE_NOT_FORMATTED = 2001,
    
    // excel表字段为空
    SHEET_NULL_FILED = 2100,
    
    // excel表单元格解析错误
    SHEET_CELL_PARSE_ERROR = 2200,
    // 数组类型解析错误
    SHEET_CELL_PARSE_ERROR_ARRAY = 2201,
}