# Aulas de extensões de méotodos

## ‼ Avisos

---

> \> **Este material é originalmente pertencente à Alura, pois foi copiado da transcrição de uma de suas video aulas**

> \> **Não deixe de visitar o portal da <a href="https://alura.com.br">Alura</a> e conferir os cursos ofertados por eles!**

---

Considerando que queremos somente um método genérico — e não uma classe —, utilizaremos uma sintaxe para indicar que temos um membro genérico.

Sendo assim, o T maiúsculo entre um sinal de menor e um sinal de maior (<T>) que aplicamos anteriormente ao nome da classe (ListExtensoes), será aplicado ao método AdicionarVarios(), da mesma maneira:

```C#
public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
{
        foreach(T item in itens)
        {
                lista.Add(item);
        }
}
```

> **O uso da letra T é uma convenção para nomear tipo de argumento genérico.**

Repare que o código é compilado, sem problemas. Portanto, podemos, sim, ter um método genérico e implementá-lo em uma classe normal.

Agora que temos um método genérico, se analisarmos as chamadas de AdicionarVarios() que fizemos anteriormente, a partir de ListExtensoes, estarão com o nome da classe sublinhado em vermelho, no caso em:

```C#
ListExtensoes<int>.AdicionarVarios(idades, 2, 3, 4);
```

E em:

```C#
ListExtensoes<string>.AdicionarVarios(nomes, "Lucas", "Mariana");
```

Como elas não fazem mais sentido, deixaremos as linhas comentadas, adicionando duas barras (//) no início delas.

Na sequência, para chamar AdicionarVarios(), por exemplo para idades, abaixo da lista de idades.Add(), adicionaremos:

```C#
idades.AdicionarVarios<int>(54, 5465, 456);
```

Atenção à especificação do tipo do método — que definimos como genérico. Em função disso, especificamos o tipo como int, considerando que o chamado é feito por idades. Não precisamos mais preencher o primeiro argumento, já que em um método de extensão ele é a referência que estamos estendendo. Podemos inserir os valores de idades diretamente.

O compilador não aponta erros, o código funciona exatamente da forma que queríamos. Ainda temos um método de extensão, que é genérico, e pode ser usado com qualquer tipo de lista. Maravilha!

Talvez, você tenha notado que o Visual Studio coloriu a fonte de int, que inserimos como tipo de AdicionarVarios(), com uma cor mais clara. Essa é uma sinalização de que o texto colorido pode ser apagado. Sendo assim, deletaremos int e o código continuará sendo compilado, sem problemas:

```C#
idades.AdicionarVarios(54, 5465, 456);
```

Mas, estamos chamando o método AdicionarVarios() com a lista de inteiros, e nenhum erro é apontado? Como o compilador sabe que AdicionarVarios() se transformará em um tipo genérico de int? O tipo genérico T — definido no método — é o mesmo da lista (List<T>).

Então, quando temos esta formação: um método genérico, que depende de um argumento, que também é uma classe genérica, e ambos argumentos genéricos são iguais — como no caso de AdicionarVarios<T>() e List<T> —, ao chamar AdicionarVarios() com uma lista de inteiro, o compilador infere que T de List<T> é um int.

Se chamarmos isso com uma lista de string, sabendo que T é uma string, não precisamos repetir essa informação. Por isso, a fonte do tipo na chamada do método fica colorida em tom mais claro. E é por isso que a chamada que já tínhamos escrito funciona:

```C#
nomes.AdicionarVarios("Lucas", "Mariana");
```

Funciona porque chamamos AdicionarVarios() em uma lista de string. E essa string é o argumento genérico da lista e usado como argumento genérico do método de extensão AdicionarVarios<T>().

Trabalharemos um exemplo para deixar essa ideia mais clara. Se temos um método de extensão, como TesteGenerico():

```C#
public static void  TesteGenerico<T2>(this string texto)
{

}
```

Utilizamos T2 como argumento genérico para diferenciar de T. Como é um método de extensão, antes dos argumentos, inserimos this.

Na sequência, deixamos bastante claro que é um método de extensão de string. Não desenvolvemos o escopo de TesteGenerico(), pois estamos somente analisando a sintaxe desse código.

Sabemos que TesteGenerico() é um método de extensão de string. Portanto, abaixo de idades.AdicionarVarios(), adicionaremos:

```C#
string guilherme = "Guilherme";
guilherme.TesteGenerico();
```

Mas, no trecho acima, não podemos escrever TesteGenerico() dessa forma, pois ele é genérico. Sendo assim, precisamos preencher o argumento genérico, dizendo que é um int, por exemplo:

```C#
string guilherme = "Guilherme";

guilherme.TesteGenerico<int>();
```

Nesse caso, somos obrigados a dizer que é int, porque a string não é uma classe genérica. Se não é uma classe genérica, ela não vai trazer informações para o compilador de que o tipo genérico dessa classe é o mesmo tipo do método TesteGenerico<T2>().

O contrário acontece em AdicionarVarios<T>(), no qual aproveitamos que List<T> é uma classe genérica, utilizando o mesmo tipo genérico de AdicionarVarios<T>().

Agora que criamos o método de extensão genérico e aprendemos como o compilador consegue inferir tipos genéricos, vamos aplicar o que estudamos a Program.cs.

Podemos apagar as seguintes linhas que deixamos como comentários ou utilizamos somente para teste, anteriormente:

```C#
// ListExtensoes.AdicionarVarios(idades, 1, 5687, 1987, 1567, 987);
idades.AdicionarVarios(5, 448, 7898, 4564);

// idades.Remove(5);
```

Na sequência, vamos aplicar um teste na lista de idades, com a sintaxe que planejamos, adicionando abaixo de idades.Add(61);:

```C#
idades.AdicionarVarios(45, 89, 12);
```

Não funciona. O Visual Studio não encontra o método AdicionarVarios(). Mas como ele vai encontrar o método de extensão?

Anteriormente, estudamos que, quando existe um método de extensão, ele será convertido para a chamada da classe estática. Então, no fim, teremos algo equivalente a:

```C#
ListExtensoes.AdicionarVarios(idades, 45, 89, 12);
```

O compilador encontrou AdicionarVarios() e constatou que a classe List<int> não possui o método chamado AdicionarVarios(). Portanto, vai buscar uma classe estática, com métodos estáticos, de extensão, que possuem esse nome.

Essa busca será feita de forma semelhante à de classes. Sendo assim, ela começará pelo namespace da própria classe, começando pelas classes estáticas, com métodos de extensão, dentro de ByteBank.SistemaAgencia. Porém, não encontra um elemento com esse nome, apontando erro em AdicionarVarios().

Então, a busca é direcionada para a lista de using, logo no início do código. Será que existe alguma classe estática, com método de extensão, dentro de System, que tenha um elemento com o nome AdicionarVarios? Não foi encontrado em System, assim como em outros namespace.

E onde que o elemento com nome AdicionarVarios pode ser encontrado? A classe está em um namespace diferente: ByteBank.SistemaAgencia.Extensoes, que não está no cabeçalho de Program.cs, além de ser diferente do namespace dessa classe.

O namespace definido em ListExtensoes.cs, no qual se encontra a declaração de AdicionarVarios<T>(), ganhou Extensoes no momento em que criamos o diretório Extensoes no projeto.

```C#
namespace ByteBank.SistemaAgencia.Extensoes
```

É assim que o compilador encontra métodos de extensão. Quando usamos uma classe, precisamos ter o módulo using referente a ela. Da mesma forma, é necessário aplicar o módulo using para localizar o método de extensão. Portanto, adicionaremos à lista:

```C#
using ByteBank.SistemaAgencia.Extensoes;
```

Feito isso, o sublinhado vermelho de AdicionarVarios() em Program.cs desaparecerá, pois terá sido encontrado pelo compilador. Vamos nos certificar de que o código funciona, executando-o. Como retorno, obteremos:

```bash
1
5
14
25
38
61
45
89
12
```

Maravilha! Foram impressas as idades: 45, 89 e 12, de acordo com o que inserimos como argumento em:

```C#
idades.AdicionarVarios(45, 89, 12);
```
