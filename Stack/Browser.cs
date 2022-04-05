internal class Browser
{
	public string Current { get; private set; } = "vazia";
	public Stack<string> Previous { get; private set; }
	public Stack<string> Next { get; private set; }
	public Browser()
	{
		Previous = new Stack<string>();
		Next = new Stack<string>();
		Print();
	}
	private void Print(string msg = "")
	{
		if (!string.IsNullOrEmpty(msg))
			System.Console.WriteLine(msg);
		System.Console.WriteLine($"Página atual: {Current}");
	}

	internal void BrowseNext()
	{
		if (Next.Any())
		{
			Previous.Push(Current);
			Current = Next.Pop();
			Print();
		}
	}

	internal void BrowseTo(string url)
	{
		Previous.Push(Current);
		Current = url;
		Print();
	}
	internal void BrowsePrevious()
	{
		if (Previous.Any())
		{
			Next.Push(Current);
			Current = Previous.Pop();
			Print();
		}
	}
}

/*
- Current: caelum
> to: google
> to: caelum
> to: alura
> goPrevious()
> goPrevious()
> goNext()
- Previous: vazia, google,
- Next: alura, 
*/