public class Program
{
	public static void Main()
	{
		Courses csharpCollections = new Courses("C# Coleções", "Marcelo");
		csharpCollections.Add(new Classes(Model.aulaLists, 21));
		csharpCollections.Add(new Classes(Model.newAula, 20));
		csharpCollections.Add(new Classes(Model.aulaModelando, 24));

		Students a1 = new Students("Vanessa Tonini", 34672);
		Students a2 = new Students("Ana Losnak", 5617);
		Students a3 = new Students("Rafael Nercessian", 17645);
		Students a4 = new Students("Vanessa Tonini", 34672);

		csharpCollections.AddEnrollment(a1);
		csharpCollections.AddEnrollment(a2);
		csharpCollections.AddEnrollment(a3);

		Console.WriteLine($"O aluno {a1.Name} está matriculado?");
		Console.WriteLine(csharpCollections.IsRegistered(a1));
		Console.WriteLine(csharpCollections.IsRegistered(a4));
		Console.WriteLine("---");

		Students a5 = csharpCollections.GetByEnrollment(5617);
		Console.WriteLine(a5);
	}
}