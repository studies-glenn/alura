namespace Helpers;

class AuthenticationHelper
{
    public bool PasswordCompare(string truePassword, string typedPassword)
    {
        return truePassword == typedPassword;
    }
} 