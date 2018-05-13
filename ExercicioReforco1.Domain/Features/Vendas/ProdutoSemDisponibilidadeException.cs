using ExercicioReforco1.Domain.Exceptions;

namespace ExercicioReforco1.Domain.Features.Vendas
{
    public class ProdutoSemDisponibilidadeException : BusinessException
    {
        public ProdutoSemDisponibilidadeException() : base("Produto deve ter Disponibilidade!")
        {
        }
    }
}

