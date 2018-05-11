using System.Collections.Generic;

namespace ExercicioReforco1.Domain.Features.Vendas
{
    public interface IVendaRepository
    {
        Venda Save(Venda venda);

        void Update(Venda venda);

        Venda Get(long id);

        IList<Venda> GetAll();

        void Delete(Venda venda);
    }
}
