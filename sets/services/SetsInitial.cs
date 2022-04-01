namespace Services;

public class SetsInitial
{
	public void Execute()
	{
		//Propriedades do Set
		//1. não permite duplicidade
		//2. os elementos não são mantidos em ordem específica

		//?Vantagem: 'Sets' é mais rápido para buscas do que 'Lists'
		//?Desvantagem: Ocupa mais memória do que listas, devido a algo conhecido
		//?como "tabela de espalhamento"
		//*Tabela de espalhamento: Ocupa mais memória do que listas

		ISet<string> students = new HashSet<string>();
		students.Add("Vanessa Tonini");
		students.Add("Ana Losnak");
		students.Add("Rafael Nercessian");

		// System.Console.WriteLine(string.Join('\n', students));

		students.Add("Priscila Stuani");
		students.Add("Rafael Rollo");
		students.Add("Fabio Gushiken");

		// System.Console.WriteLine(string.Join('\n', students));
		students.Remove("Ana Losnak");
		students.Add("Marcelo Oliveira");


		System.Console.WriteLine(string.Join('\n', students));
	}
}