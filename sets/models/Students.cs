public class Students
{
	public string Name { get; private set; }
	public int Enrollment { get; private set; }
	public Students(string name, int enrollment)
	{
		Name = name;
		Enrollment = enrollment;
	}

	public override string ToString()
	{
		return $"Name: {Name} - Enrollment: {Enrollment}";
	}

	public override bool Equals(object? obj)
	{
		Students student = obj as Students;
		if (student is null) return false;
		return Name.Equals(student.Name);
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode();
	}
}