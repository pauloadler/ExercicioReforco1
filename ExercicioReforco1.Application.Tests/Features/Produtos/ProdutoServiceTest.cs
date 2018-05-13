using ExercicioReforco1.Application.Features.Produtos;
using ExercicioReforco1.Common.Tests.Features.Produtos;
using ExercicioReforco1.Domain.Features.Produtos;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExercicioReforco1.Application.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoServiceTest
    {
        Mock<IProdutoRepository> _produtoRepositoryMockObject;
        ProdutoService _produtoService;
        Produto _produtoDefaultWithId;

        [SetUp]
        public void ProdutoServiceTestSetUp()
        {
            _produtoRepositoryMockObject = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_produtoRepositoryMockObject.Object);
            _produtoDefaultWithId = ProdutoObjectMother.DefaultWithId;
        }

        [Test]
        public void Add_Deveria_incluir_Novo_Produto()
        {
            //Arrange
            _produtoRepositoryMockObject.Setup(p => p.Save(It.IsAny<Produto>())).Returns(_produtoDefaultWithId);

            //Action 
            Produto retornoProduto = _produtoService.Add(_produtoDefaultWithId);

            //Assert
            _produtoRepositoryMockObject.Verify(p => p.Save(It.IsAny<Produto>()));
            _produtoRepositoryMockObject.Verify(p => p.Save(It.IsAny<Produto>()), Times.Once());
            retornoProduto.Id.Should().BeGreaterThan(0);
            retornoProduto.Id.Should().Be(_produtoDefaultWithId.Id);
        }

        [Test]
        public void Update_Deveria_atualizar_Os_Dados_De_Produto()
        {
            //Arrange
            _produtoRepositoryMockObject.Setup(p => p.Update(It.IsAny<Produto>()));

            //Action
            Action actionProdutoUpdate = () => { _produtoService.Update(_produtoDefaultWithId); };

            //Assert
            actionProdutoUpdate.Should().NotThrow<Exception>();
            _produtoRepositoryMockObject.Verify(p => p.Update(It.IsAny<Produto>()), Times.Once());
            _produtoRepositoryMockObject.Verify(p => p.Update(It.IsAny<Produto>()));
        }

        [Test]
        public void Get_Deveria_Retornar_Um_Produto()
        {
            //Arrange
            _produtoRepositoryMockObject.Setup(p => p.Get(It.IsAny<long>())).Returns(_produtoDefaultWithId);

            //Action 
            Produto retornoProduto = _produtoService.Get(_produtoDefaultWithId.Id);

            //Assert
            _produtoRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()));
            _produtoRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()), Times.Once());
            retornoProduto.Id.Should().BeGreaterThan(0);
            retornoProduto.Id.Should().Be(_produtoDefaultWithId.Id);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_Os_Produtos()
        {
            //Arrange
            IList<Produto> _produtoDefaultList = ProdutoObjectMother.DefaultListProdutos;

            _produtoRepositoryMockObject.Setup(p => p.GetAll()).Returns(_produtoDefaultList);

            //Action
            var resultProdutos = _produtoService.GetAll();

            //Assert
            _produtoRepositoryMockObject.Verify(x => x.GetAll());
            resultProdutos.Should().NotBeEmpty();
            resultProdutos.Should().HaveCount(3);
        }

        [Test]
        public void Delete_Deveria_Deletar_Um_Produto()
        {
            //Arrange
            _produtoRepositoryMockObject.Setup(x => x.Delete(_produtoDefaultWithId));

            //Action
            Action produtoDeleteAction = () => _produtoService.Delete(_produtoDefaultWithId);
            
            //Assert
            produtoDeleteAction.Should().NotThrow<Exception>();
            _produtoRepositoryMockObject.Verify(x => x.Delete(_produtoDefaultWithId), Times.Once());
            _produtoRepositoryMockObject.Verify(x => x.Delete(_produtoDefaultWithId));
        }
    }
}
