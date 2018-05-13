using ExercicioReforco1.Domain.Features.Vendas;
using System.Collections.Generic;

namespace ExercicioReforco1.Application.Features.Vendas
{
    public interface IVendaService
    {
        Venda Add(Venda venda);

        void Update(Venda venda);

        Venda Get(long id);

        IList<Venda> GetAll();

        void Delete(Venda venda);
    }
}
