using ExercicioReforco1.Domain.Exceptions;

namespace ExercicioReforco1.Domain.Features.Vendas
{
    public class ProdutoForaDaDataDeValidadeException : BusinessException
    {
        public ProdutoForaDaDataDeValidadeException() : base("Produto Fora da data de validade!")
        {
        }
    }
}
