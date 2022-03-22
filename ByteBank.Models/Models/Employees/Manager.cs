namespace Models;

public class Manager : AuthenticatedUsers
{
    public Manager(string cpf) : base (5000, cpf) { }
    
    public override double GetBonus() => Salary * 0.5;
    internal protected override void SalaryIncrease() => Salary *= 1.15;
}