namespace Models;

/*
! Inheritance :: A class inherits a "mother class" (Only one)
! Contract :: A class can implement multiple Interfaces
! Hierarchy of implementations	:: First comes the Inheritance, and after all Contracts
! Ex: AuthenticatedUsers : Inherits Employee, Implements IAuthenticateUser contract
*/
public abstract class AuthenticatedUsers : Employee, IAuthenticateUser
{
	private AuthenticationHelper _authenticationHelper = new AuthenticationHelper();
	public string Password { get; set; }
	public AuthenticatedUsers(double salary, string cpf) : base(salary, cpf) { }
	public bool Authenticate(string password) => _authenticationHelper.PasswordCompare(Password, password);
}