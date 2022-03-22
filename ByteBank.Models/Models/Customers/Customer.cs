namespace Models;

public class Customer
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Occupation { get; set; }

    public override bool Equals(object obj)
    {
        // ! Customer testObject = (Customer)obj; This casting may throw Exception
        // ! This casting will transform any other type to Null if they are not of 'Customer' type
        if(!(obj is Customer) && (obj is null)) return false;


        Customer testObject = obj as Customer;
        return Cpf == testObject.Cpf;
    }
}