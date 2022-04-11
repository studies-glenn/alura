public class Program
{
	public static void Main(string[] args)
	{
		//família 1: Família Flinstones
		//família 2: Família Simpsons
		//família 3: Família Dona Florinda

		//Jagged array == Array of Arrays
		string[][] familias = new string[3][];
		familias[0] = new string[] { "Fred", "Wilma", "Pedrita" };
		familias[1] = new string[] { "Homer", "Marge", "Lisa", "Bart", "Meggie" };
		familias[2] = new string[] { "Florinda", "Kiko" };

		foreach (var familia in familias)
		{
			System.Console.WriteLine(string.Join(',', familia));
		}
	}

	private static void JaggedArray()
	{

	}

	private static void MultidimensionalArray()
	{
		string[,] resultados = new string[3, 3];
		//{
		//        {"Alemanha", "Espanha", "Itália"},
		//        {"Argentina", "Holanda", "França"},
		//        {"Holanda", "Alemanha", "Alemanha"},
		//};

		resultados[0, 0] = "Alemanha";
		resultados[1, 0] = "Argentina";
		resultados[2, 0] = "Holanda";

		resultados[0, 1] = "Espanha";
		resultados[1, 1] = "Holanda";
		resultados[2, 1] = "Alemanha";

		resultados[0, 2] = "Itália";
		resultados[1, 2] = "França";
		resultados[2, 2] = "Alemanha";

		/*
		? GetUpperBound() :: Calculates the limits of a given index
		* ** The limits to give to this methos are according to the array
		* ** dimensions [row, col] <=> [0, 1]
		*/

		for (int copa = 0; copa <= resultados.GetUpperBound(1); copa++)
		{
			int ano = 2014 - copa * 4;
			Console.Write(ano.ToString().PadRight(18));
		}
		Console.WriteLine();
		for (int posicao = 0; posicao <= resultados.GetUpperBound(0); posicao++)
		{
			for (int copa = 0; copa <= resultados.GetUpperBound(1); copa++)
			{
				Console.Write($"{resultados[posicao, copa]}[{posicao},{copa}]".PadRight(18));
			}
			Console.WriteLine();
		}
		Console.WriteLine();
	}
}