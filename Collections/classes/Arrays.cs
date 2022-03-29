partial class Program
{
	static string aulaIntro = "Introdução às coleções";
	static string aulaModelando = "Modelando a Classe Aula";
	static string aulaSets = "Trabalhando com conjuntos";


	//! Arrays são coleções de tamanho fixo
	static void Arrays()
	{

		//? Array inicializado com valores predefinidos
		//* string[] aulas = new string[]
		//* {
		//* 	aulaIntro,
		//* 	aulaModelando,
		//* 	aulaSets
		//* };

		//? Array inicializado com tamanho predefinido
		string[] aulas = new string[3];
		aulas[0] = aulaIntro;
		aulas[1] = aulaModelando;
		aulas[2] = aulaSets;
		Print(aulas);

		IndexOfElement(aulas);
	}

	private static void Print(string[] aulas)
	{
		for (int i = 0; i < aulas.Length; i++)
		{
			string? aula = aulas[i];
			System.Console.WriteLine($"Aula: {aula}");
		}
	}

	private static void IndexOfElement(string[] aulas)
	{
		Console.WriteLine($"Aula modelando está no idx: {Array.IndexOf(aulas, "Modelando a Classe Aula")}");

		//! 'LastIndexOf' busca pela última ocorrência do parâmetro de busca passado a ele
		//! neste exemplo: aulaModelando
		Console.WriteLine(Array.LastIndexOf(aulas, aulaModelando));

		//? Inverte a ordem do array
		Array.Reverse(aulas);

		//? Internamente cria uma cópia do array, com o tamanho definido, e então 
		//? copia os valores para o novo array
		Array.Resize(ref aulas, 2);
		Array.Sort(aulas);

		string[] copy = new string[2];
		//? Cria uma cópia do array indicado no primeiro parâmetro
		//* aulas: soureArray
		//* 1: startIndex dentro do source
		//* copy: targetArray
		//* 0: startIndex dentro do target
		//* 2: size do target
		Array.Copy(aulas, 1, copy, 0, 2);

		string[] clone = aulas.Clone() as string[];

		//? 'Clear' altera o valor dos objetos que estão entre o 'startIndex' e o 'lastIndex'
		//? para 'null'
		//* clone: Array para limpar
		//* 1: startIndex
		//* 2: lastIndex
		Array.Clear(clone, 1, 2);
	}
}