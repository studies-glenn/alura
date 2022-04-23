using ByteBank.Agencias.DAL.Models;

public class Program
{
    private static readonly ByteBankContext dbContext = new ByteBankContext();
    public static void Main()
    {
        var lstAgencias = dbContext.Agencias.ToList();

        Console.WriteLine(string.Join("\n", lstAgencias));
    }
}