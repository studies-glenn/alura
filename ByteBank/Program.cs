/*
* propriedades de classe { 
*   - Nome de propriedade começa sempre com letra MAIÚSCULA;
*   - sempre contém get; set;
*   - sempre são públicas
*   - tipos {
*       - public int Number { get; set; }
*       - public double Balance {
*           get {
*               return _balance;
*           }
*           set {
*               if(value < 0) return;
*               _balance = value;
*           }
*       }
*   }
* }
*   - no segundo caso, a propriedade "Balance" está associada a um atributo/campo privado da classe
*   - campos que são características da Classe, como um todo, são definidos como 'static'
*/


/*
*   Classes abstratas: são classes que não permitem que sejam criadas 
*   instâncias dela, sendo obrigatória a instanciação de classes filhas da classe abstrata
*
*   Métodos virtuais: são métodos que possuem uma implementação padrão, mas permitem que classes
*   que herdam a classe "mãe" implementem sobrescrevam essas implementações. Caso não haja sobrescrita
*   desses métodos, o método da classe "mãe" será utilizado.
*   
*   Métodos abstratos: são métodos que não possuem implementação, obrigando as classes filhas da classe abstrata
*   a implementarem sua própria lógica acerca destes
*/
class Program
{
    public static void Main(string[] args){
        LoadAccounts();
        Console.WriteLine("End of application.");
    }

    private static void LoadAccounts(){
        // ! Para usar o 'using' é necessário que a classe do objeto usado
        // ! implementa a interface 'IDisposable'
        // ! Em nosso exemplo foi implementada a interface IDisposable
        // ! então, dentro do método 'Dispose', chamamos o método que fecha o arquivo.
        using(FileReader reader = new FileReader("accounts.txt")){
            reader.ReadNextLine();
            reader.ReadNextLine();
            reader.ReadNextLine();
            reader.ReadNextLine();
        }
        
    }

    private static void InnerEx(){
        try
        {
            Customer glenn = new Customer();
            Customer pam = new Customer();
            CurrentAccount cGlenn = new CurrentAccount(glenn, 0001, 765664);
            CurrentAccount cPam = new CurrentAccount(glenn, 0001, 765655);
            cGlenn.Transfer(500, cPam);
            Console.WriteLine($"Tax: {CurrentAccount.Tax}");
        }
        catch (CurrentAccountException e)
        {
            Console.WriteLine($"{e.GetType()} - {e.Message}");
            Console.WriteLine($"{e.StackTrace}");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"{e.InnerException}");
        }
    }
}