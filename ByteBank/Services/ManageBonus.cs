namespace Services;

public class ManageBonus
{
    public double TotalBonus { get; private set; }

    public void Register(Employee employee){
        TotalBonus += employee.GetBonus();
    }
}