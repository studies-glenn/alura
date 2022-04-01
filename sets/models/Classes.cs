public class Classes : IComparable
{
	public string Title { get; set; }
	public int Time { get; set; }

	public Classes(string title, int time)
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
		var cls = obj as Classes;
		return Title.CompareTo(cls.Title);
	}
}