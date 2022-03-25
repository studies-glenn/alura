using System.Text.RegularExpressions;
using ByteBankAgencySystem.Models;
using Comparables;
using Extensions;
using Models;
using Services;

namespace ByteBankAgencySystem
{
	class Program
	{
		public static void Main(string[] args)
		{
			SortingLists();

			System.Console.WriteLine("End of process...");
		}

		private static void SortingLists()
		{
			var ages = new List<int>();
			ages.AddRange(38, 10, 52, 44, 25);

			ages.Sort();

			foreach (var age in ages)
			{
				System.Console.WriteLine($"Age: {age}");
			}

			var names = new List<string> {
				"Glenn",
				"Ana",
				"Pamela",
				"Ariana"
			};
			names.Sort();

			foreach (var name in names)
			{
				System.Console.WriteLine($"Name: {name}");
			}

			var accounts = new List<CurrentAccount>()
			{
				new CurrentAccount(341, 57480),
				new CurrentAccount(342, 45678),
				new CurrentAccount(340, 1),
				null,
				new CurrentAccount(340, 48950),
				new CurrentAccount(290, 18950),
			};
			// Default IComparable Sort
			// accounts.Sort();
			// accounts.Sort(new CurrentAccountComparable());

			// *TIP*: See Lambda expressions documentation
			var orderedAccounts = accounts
									.Where(account => account is not null)
									.OrderBy(account => account.Number).ToList();

			foreach (var account in orderedAccounts)
			{
				System.Console.WriteLine($"Account: {account.Number}, Ag. {account.Agency}");
			}
		}


		private static void DotNetList()
		{
			List<int> lst = new List<int>();
			lst.Add(43);
			//! The default "List" type that come from dotNet library
			//! does not implement an "AddRange" like ours
			//! It forces us to declare an Array of the type we are dealling with
			lst.AddRange(new int[] { 16, 20, 11 });

			//? This is the extended method we've created 
			//? into the class ListExtensions
			lst.AddRange(10, 15, 20, 25, 30);

			//! It also works in this way:
			ListExtensions.AddRange(lst, 8, 9, 5, 6);

			for (int i = 0; i < lst.Count; i++)
			{
				System.Console.WriteLine($"Item at {i}: {lst[i]}");
			}
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
			System.Console.WriteLine($"---\nAvg: {accumulator / ages.Length}");
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