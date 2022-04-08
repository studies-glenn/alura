public class Student
{
	public string Name { get; private set; }
	public int Enrollment { get; private set; }
	public Student(string name, int enrollment)
	{
		Name = name;
		Enrollment = enrollment;
	}

	public override string ToString()
	{
		return $"[Student: {Name}, Enrollment: {Enrollment}]";
	}
}