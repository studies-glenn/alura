
namespace Services;

public class FileReader : IDisposable
{
    public string File { get; }

    public FileReader(string file)
    {
        File = file;

        throw new FileNotFoundException();
        // Console.WriteLine($"Opening file: {file}");
    }

    public string ReadNextLine()
    {
        Console.WriteLine("Reading line...");
        throw new IOException();
        // return "Line.";
    }

    public void CloseFile()
    {
        Console.WriteLine("Closing file.");
    }

    public void Dispose()
    {
        CloseFile();
    }
}