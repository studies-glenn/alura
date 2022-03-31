namespace Services;

public class CoursesServices
{
	public static void Execute()
	{
		var csharpCollections = new Courses("C# Collections", "Marcelo");

		//! Code smell :: Exposição indecente
		//! é permitir que propriedades internas da
		//! nossa classe sejam manipuladas de fora dela
		//! csharpCollections.Classes.Add(new Classes("Trabalhando com listas", 21));

		csharpCollections.Add(new Classes("Criando uma aula", 20));
		csharpCollections.Add(new Classes("Modelando com Coleções", 19));
		csharpCollections.Add(new Classes("Trabalhando com listas", 21));
		Print(csharpCollections.Classes);
		Console.WriteLine("---");

		Console.WriteLine(csharpCollections.ToString());
	}
	private static void Print(IList<Classes> list)
	{
		foreach (var item in list)
		{
			Console.WriteLine(item.ToString());
		}
	}
}