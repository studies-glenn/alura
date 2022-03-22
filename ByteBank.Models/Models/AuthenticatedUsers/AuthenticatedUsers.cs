namespace Models;

public abstract class AuthenticatedUsers : Employee, IAuthenticateUser
{
    private AuthenticationHelper _authenticationHelper = new AuthenticationHelper();
    public string Password { get; set; }
    public AuthenticatedUsers(double salary, string cpf) : base(salary, cpf) { }
    public bool Authenticate(string password) => _authenticationHelper.PasswordCompare(Password, password);
}