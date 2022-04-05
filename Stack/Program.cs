public class Program
{
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