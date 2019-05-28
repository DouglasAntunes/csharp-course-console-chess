using System;
using TabuleiroNS;
using TabuleiroNS.Enums;
using Xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);

                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
                tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 2));

                Tela.ImprimirTabuleiro(tabuleiro);

                Console.WriteLine();
                PosicaoXadrez pos = new PosicaoXadrez('a', 1);
                Console.WriteLine(pos);
                Console.WriteLine(pos.ToPosicao());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
