public class Month : IComparable
{
    public Month(string name, int days)
    {
        Name = name;
        Days = days;
    }

    public string Name { get; private set; }
    public int Days { get; private set; }

    public int CompareTo(object? obj)
    {
        var otherMonth = obj as Month;
        return Name.CompareTo(otherMonth.Name);
    }

    public override string ToString()
    {
        return $"Month: {Name}\tDays: {Days}";
    }
}