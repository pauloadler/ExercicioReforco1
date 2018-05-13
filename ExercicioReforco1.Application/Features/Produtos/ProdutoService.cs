using System.Collections.Generic;
using ExercicioReforco1.Domain.Features.Produtos;

namespace ExercicioReforco1.Application.Features.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository ProdutoRepository)
        {
            _produtoRepository = ProdutoRepository;
        }

        public Produto Add(Produto produto)
        {
            return _produtoRepository.Save(produto);
        }

        public void Update(Produto produto)
        {
            _produtoRepository.Update(produto);
        }
        public Produto Get(long id)
        {
            return _produtoRepository.Get(id);
        }

        public IList<Produto> GetAll()
        {
            return _produtoRepository.GetAll();
        }

        public void Delete(Produto produto)
        {
            _produtoRepository.Delete(produto);
        }
    }
}
