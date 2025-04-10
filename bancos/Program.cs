using System;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Olá, mundo!");
        string entrada = "";
        do {
            entrada = Console.ReadLine();
        } while (entrada != "-1");
    }
}