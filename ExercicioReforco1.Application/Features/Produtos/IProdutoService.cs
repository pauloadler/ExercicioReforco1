using ExercicioReforco1.Domain.Features.Produtos;
using System.Collections.Generic;

namespace ExercicioReforco1.Application.Features.Produtos
{
    public interface IProdutoService
    {
        Produto Add(Produto produto);

        void Update(Produto produto);

        Produto Get(long id);

        IList<Produto> GetAll();

        void Delete(Produto id);
    }
}
