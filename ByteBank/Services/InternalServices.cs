namespace Services;

public class InternalServices
{
    public bool LogIn(IAuthenticateUser user, string password){
        bool userAuthenticated = user.Authenticate(password);
        
        if(!userAuthenticated) {
            Console.WriteLine("Invalid User/ Password !");
            return false;
        }
        
        Console.WriteLine($"Welcome!");
        return true;
    }
}