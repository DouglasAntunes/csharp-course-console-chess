using TabuleiroNS.Enums;

namespace TabuleiroNS
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; } = null;
        public Cor Cor { get; protected set; }
        public int QuantidadeDeMovimentos { get; protected set; } = 0;
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Tabuleiro = tabuleiro;
            Cor = cor;
        }

        public void IncrementarQuantidadeDeMovimentos()
        {
            QuantidadeDeMovimentos++;
        }

        public void DecrementarQuantidadeDeMovimentos()
        {
            QuantidadeDeMovimentos--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] matrizDeMovimentos = MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (matrizDeMovimentos[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected bool PodeMover(Posicao pos)
        {
            Peca peca = Tabuleiro.Peca(pos);
            return peca == null || peca.Cor != Cor;
        }

        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
