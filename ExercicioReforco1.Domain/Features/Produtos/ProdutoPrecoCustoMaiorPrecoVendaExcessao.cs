using ExercicioReforco1.Domain.Exceptions;

namespace ExercicioReforco1.Domain.Features.Produtos
{
    public class ProdutoPrecoCustoMaiorPrecoVendaExcessao : BusinessException
    {
        public ProdutoPrecoCustoMaiorPrecoVendaExcessao() : base("Preço de Custo não pode ser maior que preço de venda!")
        {
        }
    }
}
