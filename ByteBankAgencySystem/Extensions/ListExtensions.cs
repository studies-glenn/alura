namespace Extensions;

public static class ListExtensions
{

	//? Here we are using the term 'this' to extend a METHOD
	//? And to do so it's needed to create a STATIC method
	//? inside a STATIC class and use the term 'this' BEFORE
	//? the declaration of the first parameter
	public static void AddRange<T>(this List<T> lst, params T[] items)
	{
		foreach (T item in items)
		{
			lst.Add(item);
		}
	}
}