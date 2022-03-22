namespace Models;

public class Developer : Employee
{
    public Developer(string cpf) : base (3000, cpf) { }

    public override double GetBonus()
    {
        return Salary * 0.1;
    }

    internal protected override void SalaryIncrease() => Salary *= 0.15;
}