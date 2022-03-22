namespace Models;

public class Designer : Employee
{
    public Designer(string cpf) : base (3000, cpf) { }

    public override double GetBonus() => Salary * 0.17;

    internal protected override void SalaryIncrease() => Salary *= 1.11;
}