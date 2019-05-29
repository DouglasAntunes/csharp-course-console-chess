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

        protected bool PodeMover(Posicao pos)
        {
            Peca peca = Tabuleiro.Peca(pos);
            return peca == null || peca.Cor != Cor;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
