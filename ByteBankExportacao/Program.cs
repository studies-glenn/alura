
//? Usar o termo 'partial' indica ao compilador que essa classe é uma parte
//? de todo o código que faz parte deste arquivo, ou seja,
//? nossa classe está "dividida" em vários arquivos e, ao executar o programa
//? o compilador terá que "juntar" todas elas.
partial class Program
{
    static string FilePath { get; } = Path.Combine(Directory.GetCurrentDirectory(), "Files", "accounts.txt");
    public static void Main(string[] args)
    {
        StreamReader();
        Console.WriteLine("End of process...");
    }

    static void StreamReader()
    {
        //? Quando tem-se 2 'usings', um logo após o outro, pode-se remover as chaves
        //? do mais externo.
        //* Boa prática: manter os usinigs alinhados
        using (var fs = new FileStream(FilePath, FileMode.Open))
        using (var reader = new StreamReader(fs))
        {

            while (!reader.EndOfStream)
            {
                System.Console.WriteLine(reader.ReadLine());
            }
        }
    }
}