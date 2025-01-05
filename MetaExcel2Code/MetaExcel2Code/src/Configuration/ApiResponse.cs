namespace MetaExcel2Code.Config;

public class ApiResponse<T>
{
    
    public ErrorEnum Code { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public static ApiResponse<T> Success(T? data, string? message)
    {
        return new ApiResponse<T> { Code = ErrorEnum.SUCCESS, Message = message, Data = data };
    }

    public static ApiResponse<T> Fail(ErrorEnum code = ErrorEnum.SUCCESS, string message = "")
    {
        return new ApiResponse<T> { Code = code, Message = message };
    }
    
}