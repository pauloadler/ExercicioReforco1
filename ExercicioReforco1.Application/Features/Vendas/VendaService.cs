using System.Collections.Generic;
using ExercicioReforco1.Domain.Features.Vendas;

namespace ExercicioReforco1.Application.Features.Vendas
{
    public class VendaService : IVendaService
    {
        private IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public Venda Add(Venda venda)
        {
            return _vendaRepository.Save(venda);
        }

        public void Delete(Venda venda)
        {
            _vendaRepository.Delete(venda);
        }

        public Venda Get(long id)
        {
            return _vendaRepository.Get(id);
        }

        public IList<Venda> GetAll()
        {
            return _vendaRepository.GetAll();
        }

        public void Update(Venda venda)
        {
            _vendaRepository.Update(venda);
        }
    }
}
