using ExercicioReforco1.Domain.Features.Produtos;

namespace ExercicioReforco1.Domain.Features.Vendas
{
    public class Venda
    {
        public long Id { get; set; }
        public Produto ProdutoVenda { get; set; }
        public int Quantidade { get; set; }
        public double Lucro { get; set; }
    }
}
