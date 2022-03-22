namespace Exceptions;

public class InsufficientBalanceException : CurrentAccountException
{
    public InsufficientBalanceException()
    {
        
    }
    public InsufficientBalanceException(string? message) 
    : base(message)
    {

    }
    public InsufficientBalanceException(string? message, string? paramName) 
    : base(message, paramName)
    {

    }

    public InsufficientBalanceException(string? message, Exception? innerException) 
    : base(message, innerException)
    {
        
    }

    public InsufficientBalanceException(string? message, string? paramName, Exception? innerException) 
    : base(message, paramName, innerException)
    {
        
    }
}