namespace Services;

public class ArgumentExtractor
{
    private readonly string _args;
    public string URL { get; }
    public ArgumentExtractor(string url)
    {
        if(string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url), "Argument cannot be null");
        _args = url.Substring(url.IndexOf('?'));

        URL = url;        
    }

    public string GetValues(string argument) 
    {
        argument.ToUpper();
        string upperArgs = _args.ToUpper();

        string filter = $"{argument}=";
        int paramIndex = upperArgs.IndexOf(filter);

        string result = _args.Substring(paramIndex + filter.Length);
        int andIndex = result.IndexOf('&');
        
        if(andIndex == -1)
            return result;
        return result.Remove(andIndex); 
    }
}