using ExercicioReforco1.Application.Features.Produtos;
using ExercicioReforco1.Common.Tests.Base;
using ExercicioReforco1.Common.Tests.Features.Produtos;
using ExercicioReforco1.Domain.Features.Produtos;
using ExercicioReforco1.Infra.Data.Features.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco1.System.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoSystemTest
    {
        IProdutoRepository _produtoRepository;
        ProdutoService _produtoService;
        Produto _produtoDefault;

        [SetUp]
        public void ProdutoSystemTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _produtoRepository = new ProdutoRepository();
            _produtoService = new ProdutoService(_produtoRepository);
            _produtoDefault = ProdutoObjectMother.Default;
        }

        [Test]
        public void Sistema_Deveria_Salvar_Um_Novo_Produto_E_Retornar_Do_Banco()
        {
            //Action-Arrange
            Produto resultProduto = _produtoService.Add(_produtoDefault);

            //Assert
            resultProduto.Should().NotBeNull();
            resultProduto.Id.Should().NotBe(0);

            Produto resultGet = _produtoService.Get(resultProduto.Id);
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultProduto);
        }

        [Test]
        public void Sistema_Deveria_Alterar_Um_Produto_Pelo_Id()
        {
            //Arrange
            Produto resultProduto = _produtoService.Add(_produtoDefault);
            resultProduto.Nome = "Nome de Teste Update";

            //Action 
            _produtoService.Update(resultProduto);

            //Assert
            Produto resultGet = _produtoService.Get(resultProduto.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultProduto.Id);
            resultGet.Nome.Should().Be("Nome de Teste Update");
        }

        [Test]
        public void Sistema_Deveria_Buscar_Um_Produto_Pelo_Id()
        {
            //Arrange 
            Produto resultProduto = _produtoService.Add(_produtoDefault);

            //Action
            Produto resultGet = _produtoService.Get(resultProduto.Id);

            //Assert
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultProduto.Id);
            resultGet.Should().Equals(resultProduto);
        }

        [Test]
        public void Sistema_Deveria_Buscar_Todos_Os_Produto()
        {
            //Arrange 
            Produto resultProduto = _produtoService.Add(_produtoDefault);

            //Action
            IList<Produto> resultGetAll = _produtoService.GetAll();

            //Assert
            var ultimoProduto = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(2);
            ultimoProduto.Should().Equals(_produtoDefault);
        }

        [Test]
        public void Sistema_Deveria_Deletar_Um_Produto_Pelo_Id()
        {
            Produto resultProduto = _produtoService.Add(_produtoDefault);

            //Action
            _produtoService.Delete(resultProduto);

            //Assert
            Produto resultGet = _produtoService.Get(resultProduto.Id);
            IList<Produto> resultGetAll = _produtoService.GetAll();

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
