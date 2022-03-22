namespace Models;

public class AccountManager : AuthenticatedUsers
{
    public AccountManager(string cpf) : base (4000, cpf) { }

    public override double GetBonus() => Salary * 0.25;

    internal protected override void SalaryIncrease() => Salary *= 1.05;
}