﻿using System.Collections.Generic;
using TabuleiroNS;
using TabuleiroNS.Enums;
using TabuleiroNS.Exceptions;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; } = 1;
        public Cor JogadorAtual { get; private set; } = Cor.Branca;
        public bool Terminada { get; private set; } = false;
        public bool EmXeque { get; private set; } = false;
        private HashSet<Peca> PecasEmJogo { get; set; } = new HashSet<Peca>();
        private HashSet<Peca> PecasCapturadas { get; set; } = new HashSet<Peca>();

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            ColocarPecas();
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            PecasEmJogo.Add(peca);
        }

        private void ColocarPecas()
        {
            
            ColocarNovaPeca('h', 7, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));

            ColocarNovaPeca('b', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('a', 8, new Rei(Tabuleiro, Cor.Preta));
        }

        public Peca ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca pecaDoTurnoAtual = Tabuleiro.RetirarPeca(origem);
            pecaDoTurnoAtual.IncrementarQuantidadeDeMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(pecaDoTurnoAtual, destino);
            if (pecaCapturada != null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutarMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            EmXeque = EstaEmXeque(CorAdversariaACor(JogadorAtual));

            if(TesteXequeMate(CorAdversariaACor(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
        }

        private void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.RetirarPeca(destino);
            p.DecrementarQuantidadeDeMovimentos();
            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(p, origem);
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (!Tabuleiro.ExistePeca(pos))
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiro.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tabuleiro.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void MudaJogador()
        {
            JogadorAtual = (JogadorAtual == Cor.Branca ? Cor.Preta : Cor.Branca);
        }

        public HashSet<Peca> PecasCapturadasDaCor(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (var x in PecasCapturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogoDaCor(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (var x in PecasEmJogo)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadasDaCor(cor));
            return aux;
        }

        private Cor CorAdversariaACor(Cor cor)
        {
            return cor == Cor.Branca ? Cor.Preta : Cor.Branca;
        }

        private Peca Rei(Cor cor)
        {
            foreach (var x in PecasEmJogoDaCor(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);
            if (rei == null)
            {
                throw new TabuleiroException($"Não existe Rei da cor {cor} no tabuleiro!");
            }
            foreach (var x in PecasEmJogoDaCor(CorAdversariaACor(cor)))
            {
                bool[,] matrizDeMovimentos = x.MovimentosPossiveis();
                if (matrizDeMovimentos[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }

            foreach (var x in PecasEmJogoDaCor(cor))
            {
                bool[,] matrizDeMovimentos = x.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (matrizDeMovimentos[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutarMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if(!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
