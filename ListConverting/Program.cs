class Program
{
	static void Main()
	{
		IList<string> listaMeses = new List<string>
		{
			"Janeiro", "Fevereiro", "Março", "Abril",
			"Maio", "Junho", "Julho", "Agosto",
			"Setembro", "Outubro", "Novembro", "Dezembro"
		};
		//! This implicit conversion does not work 
		//IList<object> listaObj = listaMeses;

		string[] arrMonths = new string[]
		{
			"Janeiro", "Fevereiro", "Março", "Abril",
			"Maio", "Junho", "Julho", "Agosto",
			"Setembro", "Outubro", "Novembro", "Dezembro"
		};
		//* This implicit conversion works
		//* AKA "covariance"
		//! This is not secure because it can bring errors to
		//! the code. It happens because there is no management of
		//! the type and the compiler will not show any warnings before
		//! when you try to change arrObj[0] from 'string' to 'int' for example.
		object[] arrObj = arrMonths;
		System.Console.WriteLine(string.Join(", ", arrObj));

		//* This implicit conversion works
		//* AKA "covariance"
		//! Differently of the covariance of an array, the IEnumerable
		//! applies kind of a "management" of the type we are dealing
		//! and it will not allow the user to change types, like
		//! from 'string' to 'number', and the compiler will
		//! show an error BEFORE running the code.
		//? Also an IEnumerable list does not applies indexer
		IEnumerable<object> enumObj = listaMeses;
		System.Console.WriteLine(string.Join(", ", arrObj));

	}
}