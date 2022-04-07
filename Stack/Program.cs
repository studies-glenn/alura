public class Program
{
	/*
	* Stacks implement the "First in Last out" methodology
	* Push :: Inserts an item to Stack
	* Pop  :: Removes an item from Stack
	* Peek :: Returns the item at the top of the Stack
	* https://docs.microsoft.com/en-us/dotnet/api/system.collections.stack?view=net-6.0
	*/
	public static void Main()
	{
		var browser = new Browser();
		browser.BrowseTo("google.com");
		browser.BrowseTo("caelum.com.br");
		browser.BrowseTo("alura.com.br");
		browser.BrowsePrevious();
		browser.BrowsePrevious();
		browser.BrowsePrevious();
		browser.BrowseNext();
	}
}