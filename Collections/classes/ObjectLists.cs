namespace Classes;

public static class ObjectLists
{
	public static void Execute()
	{
		var intro = new Aulas("Introdução às coleções", 20);
		var modelando = new Aulas("Modelando a classe Aula", 18);
		var sets = new Aulas("Trabalhando com conjuntos", 16);

		List<Aulas> classes = new List<Aulas>();
		classes.Add(intro);
		classes.Add(modelando);
		classes.Add(sets);

		classes.Sort();

		Print(classes);
	}

	private static void Print(List<Aulas> list)
	{
		foreach (var item in list)
		{
			System.Console.WriteLine(item.ToString());
		}
	}
}