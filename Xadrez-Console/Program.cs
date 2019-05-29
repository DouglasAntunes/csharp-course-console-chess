using System;
using TabuleiroNS;
using TabuleiroNS.Exceptions;
using Xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.Write("\nOrigem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.Write("\nDestino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutarMovimento(origem, destino);
                }

                
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine($"TabuleiroException: {e.Message}");
                Console.WriteLine($"More Info: {e.StackTrace}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Unexpected Error: {e.Message}");
                Console.WriteLine($"More Info: {e.StackTrace}");
            }

        }
    }
}
