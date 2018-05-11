using ExercicioReforco1.Domain.Exceptions;

namespace ExercicioReforco1.Domain.Features.Produtos
{
    public class ProdutoDataValidadeMenorDataFabricacaoExcessao : BusinessException
    {
        public ProdutoDataValidadeMenorDataFabricacaoExcessao() : base("Data de validade não deve ser menor que a data de fabricacao!")
        {
        }
    }
}
