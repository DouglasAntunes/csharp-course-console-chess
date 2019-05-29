using TabuleiroNS;
using TabuleiroNS.Enums;

namespace Xadrez.Pecas
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizDeMovimentos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

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

            return matrizDeMovimentos;
        }
    }
}
