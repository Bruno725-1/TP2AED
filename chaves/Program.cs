using System;
using System.Collections.Generic;
class Program
{
    static void Main (string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string formula = Console.ReadLine();
            if (VerificarExpressao(formula))
            Console.WriteLine("Expressão válida");
            else
                Console.WriteLine("Expressão inválida");
        }
    }
    static bool VerificarExpressao (string formula)
    {
        Stack<char> pilha = new Stack<char>();
        foreach (char c in formula)
        {
            if (c == '(' || c == '[' || c == '{')
            pilha.Push(c);
            else if (c == ')' || c == ']' || c == '}')
            {
                if (pilha.Count == 0) return false;
                char topo = pilha.Pop();
                if (!AgrupadoresCorrespondem(topo, c)) return false;
            }
        }
        return pilha.Count == 0;
    }
    static bool AgrupadoresCorrespondem (char abre, char fecha)
    {
        return (abre == '(' && fecha == ')') || (abre == '[' && fecha == ']') || (abre == '{' && fecha == '}');
    }
}