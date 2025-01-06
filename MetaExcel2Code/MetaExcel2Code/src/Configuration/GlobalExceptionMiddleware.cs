using System.Text.Json;

namespace MetaExcel2Code.Config;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BusinessException ex)
        {
            await HandleBusinessExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleBusinessExceptionAsync(HttpContext context, BusinessException exception)
    {
        var response = new ApiResponse<string>
        {
            Code = exception.Code,
            Message = exception.Message,
            Data = null
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 400; // 业务异常通常返回 400 状态码

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = new ApiResponse<string>
        {
            Code = ErrorEnum.UNKNOWN_ERROR,
            Message = "An unexpected error occurred.",
            Data = null
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500; // 未处理的异常返回 500

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}