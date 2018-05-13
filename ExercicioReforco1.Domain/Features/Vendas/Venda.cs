using ExercicioReforco1.Domain.Features.Produtos;
using System;

namespace ExercicioReforco1.Domain.Features.Vendas
{
    public class Venda
    {
        public long Id { get; set; }
        public Produto ProdutoVenda { get; set; }
        public int Quantidade { get; set; }
        public double Lucro { get; set; }

        public Venda(Produto produtoVenda)
        {
            ProdutoVenda = produtoVenda;
            calculoLucro();
        }

        public void ValidaProduto()
        {
            if (ProdutoVenda.Disponibilidade == false)
            {
                throw new ProdutoSemDisponibilidadeException();
            }

            if (ProdutoVenda.DataValidade < DateTime.Now)
            {
                throw new ProdutoForaDaDataDeValidadeException();
            }
        }

        public void ValidaQuantidade()
        {
            if (Quantidade == 0)
            {
                throw new QuantidadeZeroException();
            }
        }

        public void calculoLucro()
        {
            Lucro = ProdutoVenda.PrecoVenda - ProdutoVenda.PrecoCusto;
        }

    }
}
