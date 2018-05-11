using System.Collections.Generic;

namespace ExercicioReforco1.Domain.Features.Produtos
{
    public interface IProdutoRepository
    {
        Produto Save(Produto produto);

        void Update(Produto produto);

        Produto Get(long id);

        IList<Produto> GetAll();

        void Delete(Produto produto);
    }
}
