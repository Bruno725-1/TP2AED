using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Fila: cada item é uma tupla (tempo de chegada, idade)
        Queue<(int tempoChegada, int idade)> fila80Mais = new Queue<(int, int)>();
        Queue<(int tempoChegada, int idade)> filaIdosos = new Queue<(int, int)>();
        Queue<(int tempoChegada, int idade)> filaGravidas = new Queue<(int, int)>();
        Queue<(int tempoChegada, int idade)> filaComum = new Queue<(int, int)>();

        int tempoAbsoluto = 0;
        string linha;

        while ((linha = Console.ReadLine()) != "-1")
        {
            string[] dados = linha.Split(' ');
            int tempoRelativo = int.Parse(dados[0]);
            int idade = int.Parse(dados[1]);
            bool gravida = dados.Length == 3 && dados[2] == "G";

            tempoAbsoluto += tempoRelativo;

            if (idade >= 80)
                fila80Mais.Enqueue((tempoAbsoluto, idade));
            else if (idade >= 60)
                filaIdosos.Enqueue((tempoAbsoluto, idade));
            else if (gravida)
                filaGravidas.Enqueue((tempoAbsoluto, idade));
            else
                filaComum.Enqueue((tempoAbsoluto, idade));
        }

        int tempoAtual = 0;
        int tipoFila = 0; // 0: idosos, 1: grávidas, 2: comum

        while (
            fila80Mais.Count > 0 ||
            filaIdosos.Count > 0 ||
            filaGravidas.Count > 0 ||
            filaComum.Count > 0
        )
        {
            bool atendeu = false;

            // Se tiver alguém 80+ já chegou, ele é atendido
            if (fila80Mais.Count > 0 && fila80Mais.Peek().tempoChegada <= tempoAtual)
            {
                var pessoa = fila80Mais.Dequeue();
                Console.WriteLine(pessoa.idade);
                tempoAtual += 10;
                atendeu = true;
            }
            else
            {
                // Tenta seguir o ciclo idosos → grávidas → comum
                for (int i = 0; i < 3; i++)
                {
                    int atual = (tipoFila + i) % 3;

                    if (atual == 0 && filaIdosos.Count > 0 && filaIdosos.Peek().tempoChegada <= tempoAtual)
                    {
                        var pessoa = filaIdosos.Dequeue();
                        Console.WriteLine(pessoa.idade);
                        tempoAtual += 10;
                        tipoFila = (atual + 1) % 3;
                        atendeu = true;
                        break;
                    }
                    else if (atual == 1 && filaGravidas.Count > 0 && filaGravidas.Peek().tempoChegada <= tempoAtual)
                    {
                        var pessoa = filaGravidas.Dequeue();
                        Console.WriteLine(pessoa.idade);
                        tempoAtual += 10;
                        tipoFila = (atual + 1) % 3;
                        atendeu = true;
                        break;
                    }
                    else if (atual == 2 && filaComum.Count > 0 && filaComum.Peek().tempoChegada <= tempoAtual)
                    {
                        var pessoa = filaComum.Dequeue();
                        Console.WriteLine(pessoa.idade);
                        tempoAtual += 10;
                        tipoFila = (atual + 1) % 3;
                        atendeu = true;
                        break;
                    }
                }
            }

            if (!atendeu)
                tempoAtual++; // ninguém ainda chegou, avança no tempo
        }
    }
}
