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
            GenericListExample();

			System.Console.WriteLine("End of process...");
			Console.ReadLine();
        }

		private static void GenericListExample()
		{
			GenericList<int> lst = new GenericList<int>();
			lst.Add(10);
			lst.Add(25);
			lst.Add(43);
			lst.AddRangeParams(16, 20, 11);

			for (int i = 0; i < lst.Length; i++)
			{
				System.Console.WriteLine($"Item at {i}: {lst[i]}");
			}
		}
		
		private static void SemiGenericListExample()
		{
			ObjectList lst = new ObjectList();
			lst.Add(10);
			lst.Add(25);
			lst.Add(43);
			lst.AddRangeParams(16, 20, 11);

			for (int i = 0; i < lst.Length; i++)
			{
				System.Console.WriteLine($"Item at {i}: {(int)lst[i]}");
			}
		}

		private static void ParamsExample()
		{
			CurrentAccountList accounts = new CurrentAccountList();
			// ! Without 'params' argument
			// accounts.AddRange(new CurrentAccount[]
			// {
			// 	new CurrentAccount(0001, 098123),
			// 	new CurrentAccount(0001, 854756),
			// 	new CurrentAccount(0001, 223443)
			// });

			// ! With 'params' argument
			accounts.AddRangeParams(
				new CurrentAccount(0001, 098123),
				new CurrentAccount(0001, 854756),
				new CurrentAccount(0001, 223443)
			);
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

			for (int i = 0; i < accounts.Length; i++)
			{
				System.Console.WriteLine($"Getting account on index {i}: {accounts[i].Number}");
			}

            // accounts.Print();
            // accounts.Remove(toDelete);
            // System.Console.WriteLine($"---");
            // accounts.Print();
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