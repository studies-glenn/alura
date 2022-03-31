using System.Collections.ObjectModel;

class Courses
{
	// public int TempoTotal { get; private set; }
	public int TempoTotal
	{
		get
		{
			return _classes.Sum(cls => cls.Time);
		}
	}

	private IList<Classes> _classes;
	public Courses(string course, string teatcher)
	{
		Course = course;
		Teatcher = teatcher;
		_classes = new List<Classes>();
	}

	public string Course { get; set; }
	public string Teatcher { get; set; }
	public IList<Classes> Classes
	{
		get
		{
			return new ReadOnlyCollection<Classes>(_classes);
		}
	}

	internal void Add(Classes cls)
	{
		_classes.Add(cls);
	}

	public override string ToString()
	{
		return $"Curso: {Course}\n"
			 + $"Duração: {TempoTotal}\n"
			 + $"Aulas: \n{string.Join("\n", _classes)}";
	}
}