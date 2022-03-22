namespace Models;

public abstract class Employee
{
    public static int TotalEmployee { get; private set; }
    public string CPF { get; private set; }
    public double Salary { get; protected set; }
    public string Name { get; set; }


    public Employee(double salary, string cpf)
    {
        CPF = cpf;
        Salary = salary;
        TotalEmployee++;
    }
    public abstract double GetBonus();

    internal protected abstract void SalaryIncrease();
}