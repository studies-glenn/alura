namespace Models;

public class BusinessPartner : IAuthenticateUser
{
    private AuthenticationHelper _authenticationHelper = new AuthenticationHelper();
    public string Password { get; set; }

    public bool Authenticate(string password) => _authenticationHelper.PasswordCompare(Password, password);
}