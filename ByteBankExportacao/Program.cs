
//? Usar o termo 'partial' indica ao compilador que essa classe é uma parte
//? de todo o código que faz parte deste arquivo, ou seja,
//? nossa classe está "dividida" em vários arquivos e, ao executar o programa
//? o compilador terá que "juntar" todas elas.
using Models;

partial class Program
{
	static string Root { get; } = Path.Combine(Directory.GetCurrentDirectory(), "Files");
	public static void Main(string[] args)
	{
		CreateFile();
		Console.WriteLine("End of process...");
	}

	static void StreamReader()
	{
		//? Quando tem-se 2 'usings', um logo após o outro, pode-se remover as chaves
		//? do mais externo.
		//* Boa prática: manter os usinigs alinhados
		var filePath = Path.Combine(Root, "accounts.txt");
		using (var fs = new FileStream(filePath, FileMode.Open))
		using (var reader = new StreamReader(fs))
		{

			while (!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				var account = ConvertStringToCurrentAccount(line);
				System.Console.WriteLine($"Owner: {account.Owner} - Account: {account.Number}, Ag.: {account.Agency} - Balance: {account.Balance}");
			}
		}

	}

	static CurrentAccount ConvertStringToCurrentAccount(string line)
	{
		string[] fields = line.Split(',');
		var strAgency = fields[0];
		var strNumber = fields[1];
		var strBalance = fields[2].Replace('.', ',');
		var owner = fields[3];

		var agency = int.Parse(strAgency);
		var number = int.Parse(strNumber);
		var balance = double.Parse(strBalance);

		var customer = new Customer();
		customer.Name = owner;
		var result = new CurrentAccount(agency, number);
		result.Deposit(balance);
		result.Owner = customer;

		return result;
	}

	static void CreateFile()
	{
		var fileName = Path.Combine(Root, "exportAccounts.csv");

		using (var fs = new FileStream(fileName, FileMode.Create))
		using (var writer = new StreamWriter(fs))
		{
			var account = "0001,356478,233.65,Glenn";
			writer.WriteLine(account);
			writer.Flush(); // Dump buffer into file so the OS is able to get latest changes into it
		}

	}

}