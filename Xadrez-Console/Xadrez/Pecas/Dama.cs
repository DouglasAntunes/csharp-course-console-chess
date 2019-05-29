using TabuleiroNS;
using TabuleiroNS.Enums;

namespace Xadrez.Pecas
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizDeMovimentos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matrizDeMovimentos[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.ExistePeca(pos) && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna--;
            }

            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matrizDeMovimentos[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.ExistePeca(pos) && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna++;
            }

            //Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matrizDeMovimentos[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.ExistePeca(pos) && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha--;
            }

            //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matrizDeMovimentos[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.ExistePeca(pos) && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha++;
            }

            //NO
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matrizDeMovimentos[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.ExistePeca(pos) && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            //NE
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matrizDeMovimentos[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.ExistePeca(pos) && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            //SE
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matrizDeMovimentos[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.ExistePeca(pos) && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            //SO
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matrizDeMovimentos[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.ExistePeca(pos) && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return matrizDeMovimentos;
        }
    }
}
