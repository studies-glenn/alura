namespace Services;
public static class ObjectLists
{
	public static void Execute()
	{
		var intro = new Classes("Introdução às coleções", 20);
		var modelando = new Classes("Modelando a classe Aula", 18);
		var sets = new Classes("Trabalhando com conjuntos", 16);

		List<Classes> classes = new List<Classes>();
		classes.Add(intro);
		classes.Add(modelando);
		classes.Add(sets);

		classes.Sort();

		Print(classes);
	}

	private static void Print(List<Classes> list)
	{
		foreach (var item in list)
		{
			System.Console.WriteLine(item.ToString());
		}
	}
}