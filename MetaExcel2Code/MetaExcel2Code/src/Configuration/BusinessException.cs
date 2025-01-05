namespace MetaExcel2Code.Config;

public class BusinessException: Exception
{
    public ErrorEnum Code { get; }
    
    public BusinessException(ErrorEnum code, string message) : base(message)
    {
        Code = code;
    }
}