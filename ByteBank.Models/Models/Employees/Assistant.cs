namespace Models;


public class Assistant : Employee
{

    public Assistant(string cpf) : base (2000, cpf) { }

    public override double GetBonus() => Salary * 0.20;

    internal protected override void SalaryIncrease() => Salary *= 1.10;
}