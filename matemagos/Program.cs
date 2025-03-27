using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Retirar o prompt antes de mandar para o Verde");
        int n = int.Parse(Console.ReadLine());
        int num = 0;
        int i = 0;
        if (i < n) {
            num = int.Parse(Console.ReadLine());
            Console.WriteLine(ConverterNumero(num));
            i++;
        }
        Console.WriteLine(num);
    }
    static int ConverterNumero (int num) {
        int binario = num;
        if (binario == 1) {
            return 1;
        }
        else {
            int resto = binario % 2;
            Console.Write(resto);
            return ConverterNumero(binario / 2);
        }
    }
}
