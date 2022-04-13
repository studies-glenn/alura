class Program
{
    static void Main()
    {
        List<Month> months = new List<Month>
        {
                new Month("Janeiro", 31),
                new Month("Fevereiro", 28),
                new Month("Março", 31),
                new Month("Abril", 30),
                new Month("Maio", 31),
                new Month("Junho", 30),
                new Month("Julho", 31),
                new Month("Agosto", 31),
                new Month("Setembro", 30),
                new Month("Outubro", 31),
                new Month("Novembro", 30),
                new Month("Dezembro", 31)
        };

        GroupOperators();
    }

    static void Querying(List<Month> months)
    {
        // LINQ :: Language Integrated Query
        // ? 'Select' :: Used to modify the list
        IEnumerable<Month> query = months
                                    .Where(m => m.Days == 31)
                                    .OrderBy(m => m.Name)
                                    .Select(m => new Month 
                                    ( 
                                        m.Name.ToUpper(),
                                        m.Days
                                    ));

        foreach (var item in query)
        {
            System.Console.WriteLine(item);
        }
    }

    static void LINQoperators(List<Month> months)
    {
        var query = months.Take(3);
        Print(query);

        query = months.Skip(3);
        Print(query);

        query = months.Skip(6).Take(3);
        Print(query);

        query = months.TakeWhile(m => !m.Name.StartsWith("S"));
        Print(query);

        query = months.SkipWhile(m => !m.Name.StartsWith("S"));
        Print(query);
    }
    
    static void GroupOperators() 
    {
        string[] seq1 = { "janeiro", "fevereiro", "março" };
        string[] seq2 = { "fevereiro", "MARÇO", "abril" };

        var query = seq1.Concat(seq2);
        foreach (var item in query)
        {
            System.Console.WriteLine(string.Join(',', item));
        }
        System.Console.WriteLine(new string('-', 70));

        /*
        ! This 'Union' will accept duplicate members
        ! IF they have something different, like (march, MARCH)
        */
        query = seq1.Union(seq2);
        foreach (var item in query)
        {
            System.Console.WriteLine(string.Join(',', item));
        }
        System.Console.WriteLine(new string('-', 70));

        /*
        ! This 'Union' will apply a Comparer(StringComparer in this case)
        ! to remove similar items
        */
        query = seq1.Union(seq2, StringComparer.InvariantCultureIgnoreCase);
        foreach (var item in query)
        {
            System.Console.WriteLine(string.Join(',', item));
        }
        System.Console.WriteLine(new string('-', 70));
        
        /*
        ! This 'Intersect' will return ONLY the items that are in both lists
        ! and, similar to the 'Union', will not get cases like 'march-MARCH'
        */
        query = seq1.Intersect(seq2);
        foreach (var item in query)
        {
            System.Console.WriteLine(string.Join(',', item));
        }
        System.Console.WriteLine(new string('-', 70));
        
        /*
        ! This 'Intersect' is applying a Comparer(StringComparer in this case)
        ! to get all items that are in both lists despite the differences between them
        */
        query = seq1.Intersect(seq2, StringComparer.InvariantCultureIgnoreCase);
        foreach (var item in query)
        {
            System.Console.WriteLine(string.Join(',', item));
        }
        System.Console.WriteLine(new string('-', 70));
        
        //* Gets everything inside 'seq1' and is not inside 'seq2'
        query = seq1.Except(seq2);
        foreach (var item in query)
        {
            System.Console.WriteLine(string.Join(',', item));
        }
        System.Console.WriteLine(new string('-', 70));
    }
    
    static void Print(IEnumerable<Month> query)
    {
        foreach (var item in query)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine(new string('-', 70));
    }
}