using System;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] entrada1 = Console.ReadLine().Split(' ');
        int m = int.Parse(Console.ReadLine());
        string[] entrada2 = Console.ReadLine().Split(' ');
        int[] multiplos = new int[n];
        int[] primos = new int[m];
        ConverterNumeros(multiplos, entrada1, 0);
        ConverterNumeros(primos, entrada2, 0);
        Imprimir(multiplos, primos, 0, 0);
    }
    static void ConverterNumeros(int[] vetor, string[] entrada, int index) {
        if (index == vetor.Length) return;
        vetor[index] = int.Parse(entrada[index]);
        ConverterNumeros(vetor, entrada, index + 1);
    }
    static void Imprimir (int[] v1, int[] v2, int i, int j) {
        //caso base: Se ambos os índices chegaram ao fim, termina
        if (i == v1.Length && j == v2.Length) return;
        //Se já terminamos o primeiro vetor, imprimimos os elementos restantes do segundo
        if (i == v1.Length)
        {
            Console.WriteLine(v2[j]);
            Imprimir(v1, v2, i, j + 1);
            return;
        }
        //Se já terminamos o segundo vetor, imprimimos os elementos restantes do primeiro
        if (j == v2.Length)
        {
            Console.WriteLine(v1[i]);
            Imprimir(v1, v2, i + 1, j);
            return;
        }
        //comparação para mesclar em ordem crescente
        if (v1[i] < v2[j])
        {
            Console.WriteLine(v1[i]);
            Imprimir(v1, v2, i + 1, j);
        }
        else{
            Console.WriteLine(v2[j]);
            Imprimir(v1, v2, i, j + 1);
        }
    }
}
