using ExercicioReforco1.Domain.Exceptions;

namespace ExercicioReforco1.Domain.Features.Vendas
{
    public class QuantidadeZeroException : BusinessException
    {
        public QuantidadeZeroException() : base("Quantidade deve ser maior que zero!")
        {
        }
    }
}
