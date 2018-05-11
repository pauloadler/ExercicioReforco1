using ExercicioReforco1.Domain.Exceptions;

namespace ExercicioReforco1.Domain.Features.Produtos
{
    public class ProdutoNomeNuloOuVazioExcessao : BusinessException
    {
        public ProdutoNomeNuloOuVazioExcessao() : base("Nome do produto não pode ser vazio!")
        {
        }
    }
}
