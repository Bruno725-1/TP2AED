using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        LerNumeros(n);
    }
    static void ConverterNumero (int num) {
        if (num > 1) {
            ConverterNumero(num / 2);
        }
        Console.Write(num % 2);
    }
    static void LerNumeros(int n) {
        if (n == 0)
        return;
        int num = int.Parse(Console.ReadLine());
        ConverterNumero(num);
        Console.WriteLine();
        LerNumeros(n - 1);
    }
}
