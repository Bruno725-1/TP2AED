using System;
using System.Collections.Generic;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Olá, mundo!");
        Queue <int> fila80Mais = new Queue<int>();
        Queue<int> idosos = new Queue<int>();
        Queue<int> gravidas = new Queue<int>();
        Queue<int> filaComum = new Queue<int>();
        int tempoAtual = 0;
        string linha = "";
        do
        {
            Console.WriteLine("Escreve um número");
            linha = Console.ReadLine();
            if (linha == "-1") break;
            string[] dados = linha.Split(' ');
            int tempo = int.Parse(dados[0]);
            int idade = int.Parse(dados[1]);
            //atualização do tempo de chegada para o atendimento
            tempoAtual += tempo;
            //adiciona os clientes à fila correta
            if (idade >= 80)
            fila80Mais.Enqueue(idade);
            else if (idade >= 60 && idade <= 79)
            idosos.Enqueue(idade);
            else if(EhGravida(dados))
            gravidas.Enqueue(idade);
            else
            filaComum.Enqueue(idade);
        } while (linha != "-1");
        //atendimento dos clientes
        while(fila80Mais.Count > 0 && idosos.Count > 0 && gravidas.Count > 0 && filaComum.Count > 0)
        {
            while (fila80Mais.Count > 0)
            {
                Console.WriteLine(fila80Mais.Dequeue());
                tempoAtual += 10;
            }
            if (idosos.Count > 0)
            {
                Console.WriteLine(idosos.Dequeue());
            }
            else if (gravidas.Count > 0)
            {
                Console.WriteLine(gravidas.Dequeue());
            }
            else if (filaComum.Count > 0)
            {
                Console.WriteLine(filaComum.Dequeue());
            }
            tempoAtual += 10;
        }
    }
    public static bool EhGravida (string[] dados) {
        if (dados.Length != 3)
        return false;
        if (dados.Length == 3 && dados[2] == "G")
        return true;
        return false;
    }
}