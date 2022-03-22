namespace Interfaces;

public interface IAuthenticateUser 
{
    public bool Authenticate(string password);
}