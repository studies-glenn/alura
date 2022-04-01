using System.Collections.ObjectModel;

class Courses
{
	private IList<Classes> _classes;
	// public int TempoTotal { get; private set; }
	public int TempoTotal
	{
		get
		{
			return _classes.Sum(cls => cls.Time);
		}
	}

	public string Course { get; set; }
	public string Teatcher { get; set; }
	public ISet<Students> Students { get; private set; }

	public Courses(string course, string teatcher)
	{
		Course = course;
		Teatcher = teatcher;
		Students = new HashSet<Students>();
		_classes = new List<Classes>();
	}

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

	internal void AddEnrollment(Students student)
	{
		Students.Add(student);
	}

	public bool IsRegistered(Students student)
	{
		return Students.Contains(student);
	}

	public override string ToString()
	{
		return $"Curso: {Course}\n"
			 + $"Duração: {TempoTotal}\n"
			 + $"Aulas: \n{string.Join("\n", _classes)}";
	}
}