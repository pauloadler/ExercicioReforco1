using ExercicioReforco1.Domain.Exceptions;

namespace ExercicioReforco1.Domain.Features.Produtos
{
    public class ProdutoNomeNaoAtendidoMinimoCaracteres : BusinessException
    {
        public ProdutoNomeNaoAtendidoMinimoCaracteres() : base("Nome do produto deve ter mais que 4 caracteres!")
        {
        }
    }
}
