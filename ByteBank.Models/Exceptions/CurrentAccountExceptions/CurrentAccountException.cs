namespace Exceptions;

public class CurrentAccountException : SystemException
{
    public string ParamName { get; }

    public CurrentAccountException()
    {
        
    }

    public CurrentAccountException(string? message) 
    : base(message)
    {
        
    }

    public CurrentAccountException(string? message, Exception? innerException) 
    : base(message, innerException)
    {
        
    }
    public CurrentAccountException(string? message, string? paramName) 
    : this($"{message} (Parameter '{paramName}')")
    {
        
    }

    public CurrentAccountException(string? message, string? paramName, Exception? innerException) 
    : this($"{message} (Parameter '{paramName}')", innerException)
    {
        
    }
}