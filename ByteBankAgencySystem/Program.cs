using System.Text.RegularExpressions;
using ByteBankAgencySystem.Models;
using Models;
using Services;

namespace ByteBankAgencySystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            CurrentAccountListExample();
        }

        private static void CurrentAccountListExample()
        {
            CurrentAccount toDelete = new CurrentAccount(0001, 098844);
            CurrentAccountList accounts = new CurrentAccountList();
            accounts.Add(new CurrentAccount(0001, 123123));
            accounts.Add(toDelete);
            accounts.Add(new CurrentAccount(0001, 098123));
            accounts.Add(new CurrentAccount(0001, 854756));
            accounts.Add(new CurrentAccount(0001, 223443));

            accounts.Print();
            accounts.Remove(toDelete);
            System.Console.WriteLine($"---");
            accounts.Print();
        }

        private static void CurrentAccountArray()
        {
            CurrentAccount[] accounts = new CurrentAccount[]
            {
                new CurrentAccount(0001, 123123),
                new CurrentAccount(0001, 985774),
                new CurrentAccount(0001, 727664)
            };
            for (int index = 0; index < accounts.Length; index++)
            {
                System.Console.WriteLine($"Account: {accounts[index].Number}");
            }
        }

        private static void IntArrayExample()
        {
            int accumulator = 0;
            int[] ages = new int[6];
            ages[0] = 15;
            ages[1] = 28;
            ages[2] = 35;
            ages[3] = 50;
            ages[4] = 28;
            ages[5] = 12;

            for (int i = 0; i < ages.Length; i++)
            {
                System.Console.WriteLine($"Age: {ages[i]}");
                accumulator += ages[i];
            }
            System.Console.WriteLine($"---\nAvg: {accumulator/ages.Length}");
        }

        private static void StringExample()
        {
            string url = "page?origin=real&target=dollar&value=1500";

            ArgumentExtractor ae = new ArgumentExtractor(url);
            var phoneRegex = "[0-9]{4}[-][0-9]{4}";
            phoneRegex = "[0-9]{4,5}-?[0-9]{4}";
            phoneRegex = "[0-9]{4,5}-?[0-9]{4}";
            Match r = Regex.Match("Glenn 99566-1246", phoneRegex);
            System.Console.WriteLine(r.Value);

            Console.WriteLine($"{ae.GetValues("VALUE")}");
        }
    }
}