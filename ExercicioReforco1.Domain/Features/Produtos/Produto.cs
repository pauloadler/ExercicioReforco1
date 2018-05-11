using System;

namespace ExercicioReforco1.Domain.Features.Produtos
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double PrecoVenda { get; set; }
        public double PrecoCusto { get; set; }
        public bool Disponibilidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }

        public void ValidaNome()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new ProdutoNomeNuloOuVazioExcessao();
            }
            
            if (Nome.Length < 4)
            {
                throw new ProdutoNomeNaoAtendidoMinimoCaracteres();
            }
        }

        public void ValidaPrecoCusto()
        {
            if (PrecoCusto > PrecoVenda)
            {
                throw new ProdutoPrecoCustoMaiorPrecoVendaExcessao();
            }
        }

        public void ValidaDataValidade()
        {
            if (DataValidade < DataFabricacao)
            {
                throw new ProdutoDataValidadeMenorDataFabricacaoExcessao();
            }
        }
    }
}
