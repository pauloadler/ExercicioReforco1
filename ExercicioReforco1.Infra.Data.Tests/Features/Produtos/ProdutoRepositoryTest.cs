using ExercicioReforco1.Common.Tests.Base;
using ExercicioReforco1.Common.Tests.Features.Produtos;
using ExercicioReforco1.Domain.Features.Produtos;
using ExercicioReforco1.Infra.Data.Features.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco1.Infra.Data.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoRepositoryTest
    {
        ProdutoRepository _produtoRepository;
        Produto _produtoDefault;

        [SetUp]
        public void ProdutoRepositoryTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _produtoRepository = new ProdutoRepository();
            _produtoDefault = ProdutoObjectMother.Default;
        }

        [Test]
        public void Save_Deveria_Gravar_Um_Novo_Produto()
        {
            //Action-Arrange
            Produto resultProduto = _produtoRepository.Save(_produtoDefault);

            //Assert
            Produto resultGet = _produtoRepository.Get(resultProduto.Id);

            resultProduto.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultProduto.Id);
        }

        [Test]
        public void Update_Deveria_Alterar_Os_Dados_De_Produto()
        {
            //Arrange
            Produto produtoResult = _produtoRepository.Save(_produtoDefault);
            produtoResult.Nome = "Nome de Teste Update";

            //Action
            _produtoRepository.Update(produtoResult);

            //Assert
            Produto resultGet = _produtoRepository.Get(produtoResult.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(produtoResult.Id);
            resultGet.Nome.Should().Be("Nome de Teste Update");
        }

        [Test]
        public void Get_Deveria_Retornar_Um_Produto()
        {
            //Arrange 
            Produto resultProduto = _produtoRepository.Save(_produtoDefault);

            //Action
            Produto resultGet = _produtoRepository.Get(resultProduto.Id);

            //Assert
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultProduto.Id);
            resultGet.Should().Equals(resultProduto);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_Os_Produtos()
        {
            //Arrange 
            Produto resultProduto = _produtoRepository.Save(_produtoDefault);

            //Action
            IList<Produto> resultGetAll = _produtoRepository.GetAll();

            //Assert
            var ultimoProduto = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(2);
            ultimoProduto.Should().Equals(_produtoDefault);
        }

        [Test]
        public void Delete_Deveria_Deletar_Um_Produto()
        {
            //Arrange 
            Produto resultProduto = _produtoRepository.Save(_produtoDefault);

            //Action
            _produtoRepository.Delete(resultProduto);

            //Assert
            Produto resultGet = _produtoRepository.Get(resultProduto.Id);
            IList<Produto> resultGetAll = _produtoRepository.GetAll();

            resultGet.Should().BeNull();
            resultGetAll.Should().HaveCount(1);
        }

        [TearDown]
        public void LimparDataBase()
        {
            BaseSqlTest.SeedDeleteDatabase();
        }
    }
}
