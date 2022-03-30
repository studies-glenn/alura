public class Aulas : IComparable
{
	public string Title { get; set; }
	public int Time { get; set; }

	public Aulas(string title, int time)
	{
		Title = title;
		Time = time;
	}

	public override string ToString()
	{
		return $"[Título: {Title} - Time: {Time}min]";
	}

	public int CompareTo(object? obj)
	{
		var cls = obj as Aulas;
		return Title.CompareTo(cls.Title);
	}
}