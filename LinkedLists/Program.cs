/*
	? What is a linked list?
	* * It's a list where each element has a pointer
	* * of the next element after it.
	! A linked list is **not organized** in memory
	! its elements are **spread** in memory
*/
public class Program
{
	public static void Main()
	{
		LinkedList<string> semana = new LinkedList<string>();
		/*
			! Tipo de objeto "LinkedListNode" encapsula os valores que a gente
			! quer armazenar
			? 4 Formas de adicionar um item na lista:
			? - AddFirst
			? - AddLast
			? - AddBefore
			? - AddAfter
			* var quarta = new LinkedListNode<string>("quarta-feira");
			* var quinta = new LinkedListNode<string>("quinta-feira");
			* var sexta = new LinkedListNode<string>("sexta-feira");
			* var sabado = new LinkedListNode<string>("sabado");
			* var domingo = new LinkedListNode<string>("domingo");
			* var segunda = new LinkedListNode<string>("segunda-feira");
			* var terca = new LinkedListNode<string>("terca-feira");
		*/
		var d4 = semana.AddFirst("quarta");
		var d2 = semana.AddBefore(d4, "segunda");
		var d3 = semana.AddAfter(d2, "terca");
		var d6 = semana.AddAfter(d4, "sexta");
		var d7 = semana.AddAfter(d6, "sabado");
		var d5 = semana.AddBefore(d6, "quinta");
		var d1 = semana.AddBefore(d2, "domingo");

		foreach (var dia in semana)
		{
			System.Console.WriteLine(dia);
		}
	}
}