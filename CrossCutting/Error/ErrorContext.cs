namespace CrossCutting.Error;

public class ErrorContext
{
    public ErrorType Type { get; set; }
    public bool HasError { get; set; }
    public string Message => ErrorMessage.GetMessage(Type);
    public int StatusCode => ErrorCode.GetStatusCode(Type);

    public void Add(ErrorType errorType)
    {
        HasError = true;
        Type = errorType;
    }
}
