class Program
{
	static void Main()
	{
		SortedSt();
	}

	static void Dict()
	{
		/*
			* We don't know where new items will be added in 
			* Dictionaries.
		*/
		IDictionary<string, Student> students = new Dictionary<string, Student>();
		students.Add("VT", new Student("Vanessa", 34672));
		students.Add("AL", new Student("Ana", 5617));
		students.Add("RN", new Student("Rafael", 17645));
		students.Add("WM", new Student("Wanderson", 11287));

		foreach (var item in students)
		{
			System.Console.WriteLine(item);
		}
	}

	static void SortedLst()
	{
		/*
		* Implements 2 different structures to store the Keys and their Values
		*/
		IDictionary<string, Student> students = new SortedList<string, Student>();
		students.Add("VT", new Student("Vanessa", 34672));
		students.Add("AL", new Student("Ana", 5617));
		students.Add("RN", new Student("Rafael", 17645));
		students.Add("WM", new Student("Wanderson", 11287));

		foreach (var item in students)
		{
			System.Console.WriteLine(item);
		}

		students.Remove("AL");
		students.Add("SM", new Student("Glenn", 1143));
		System.Console.WriteLine(new string('-', 70));
		foreach (var item in students)
		{
			System.Console.WriteLine(item);
		}
	}

	static void SortedDict()
	{
		/*
		* Keys :: KeyCollection, instead IList
		* Values :: ValueCollection, instead IList
		* Its implementation is like a Binary tree
		* It has a balancing algorithm
		* Insert and Remove are faster than SortedList
		*/
		IDictionary<string, Student> students = new SortedDictionary<string, Student>();
		students.Add("VT", new Student("Vanessa", 34672));
		students.Add("AL", new Student("Ana", 5617));
		students.Add("RN", new Student("Rafael", 17645));
		students.Add("WM", new Student("Wanderson", 11287));

		foreach (var item in students)
		{
			System.Console.WriteLine(item);
		}

		students.Remove("AL");
		students.Add("SM", new Student("Glenn", 1143));
		System.Console.WriteLine(new string('-', 70));
		foreach (var item in students)
		{
			System.Console.WriteLine(item);
		}
	}

	static void SortedSt()
	{
		/*
		* It implements a balanced Binary Tree to its values
		*/
		ISet<string> students = new SortedSet<string>(new LowerCaseComparer());
		students.Add("Vanessa Tonini");
		students.Add("Ana Losnak");
		students.Add("Rafael Nercessian");
		students.Add("Priscila Tuani");
		students.Add("Rafael Rollo");
		students.Add("Fabio Gushiken");
		students.Add("Fabio Gushiken");
		students.Add("FABIO GUSHIKEN");

		foreach (var item in students)
		{
			System.Console.WriteLine(item);
		}

		ISet<string> newGroup = new HashSet<string>();
		// Checks if all Students' elements are **contained** by 'newGroup' 
		students.IsSubsetOf(newGroup);
		// Checks if Students group **contains** the 'newGroup'
		students.IsSubsetOf(newGroup);
		// Checks if elements between 'students' and 'newGroup' are the same
		students.SetEquals(newGroup);
		// Returns the elements from 'newGroup' that are contained by 'students'
		// like 'left join'
		students.ExceptWith(newGroup);
		// Intersection
		students.IntersectWith(newGroup);
		// Returns all elements from 'newGroup' and 'Students' that are not
		// in the intersection
		students.SymmetricExceptWith(newGroup);
		// Union
		students.UnionWith(newGroup);
	}

}