namespace Services;

public static class Lists
{
	public static void Execute()
	{
		//? Listas também são chamadas de "arrays dinâmicos"
		List<string> classes = new List<string>
		{
			Model.aulaIntro,
			Model.aulaModelando,
			Model.aulaSets
		};
		// Print(classes);

		//* Métodos de acesso ao primeiro e último elementos da lista
		System.Console.WriteLine($"A primeira aula é: {classes.First()}");
		System.Console.WriteLine($"A última aula é: {classes.Last()}");

		//! Apesar de haver o método 'First' na definição das listas,
		//! é recomendado utilizar o médoto 'FirstOrDefault' quando for utilizar expressões lambda, 
		//! para evitar que o compilador lance excessão dizendo "A sequência não contém elementos de correspondência"
		Console.WriteLine(@$"A primeira aula que contém 'Trabalhando' é: 
		{
			classes.FirstOrDefault(item => item.Contains("Trabalhando"))
		}");
		System.Console.WriteLine("---");

		//? Busca os dois últimos elementos da lista 'classes' e copia para a lista 'copy'
		List<string> copy = classes.GetRange(classes.Count - 2, 2);

		//? Cria um clone da lista 'classes', sem criar referência para a lista original
		List<string> clone = new List<string>(classes);
		clone.RemoveAt(0);

		Print(clone);
		System.Console.WriteLine("----");
		Print(classes);
	}

	private static void Print(List<string> classes)
	{
		// foreach (var item in classes)
		// {
		// 	System.Console.WriteLine($"Class: {item}");
		// }

		// for (int i = 0; i < classes.Count; i++)
		// {
		// 	System.Console.WriteLine($"Class: {classes[i]}");
		// }

		classes.ForEach(item =>
		{
			System.Console.WriteLine($"Class: {item}");
		});
	}
}