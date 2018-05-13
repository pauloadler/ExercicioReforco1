using ExercicioReforco1.Application.Features.Vendas;
using ExercicioReforco1.Common.Tests.Features.Vendas;
using ExercicioReforco1.Domain.Features.Vendas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExercicioReforco1.Application.Tests.Features.Vendas
{
    [TestFixture]
    public class VendaServiceTest
    {
        Mock<IVendaRepository> _vendaRepositoryMockObject;
        VendaService _vendaService;
        Venda _vendaefaultWithId;

        [SetUp]
        public void ProdutoServiceTestSetUp()
        {
            _vendaRepositoryMockObject = new Mock<IVendaRepository>();
            _vendaService = new VendaService(_vendaRepositoryMockObject.Object);
            _vendaefaultWithId = VendaObjectMother.DefaultWithId;
        }

        [Test]
        public void Add_Deveria_incluir_Nova_Venda()
        {
            //Arrange
            _vendaRepositoryMockObject.Setup(p => p.Save(It.IsAny<Venda>())).Returns(_vendaefaultWithId);

            //Action 
            Venda retornoVenda = _vendaService.Add(_vendaefaultWithId);

            //Assert
            _vendaRepositoryMockObject.Verify(p => p.Save(It.IsAny<Venda>()));
            _vendaRepositoryMockObject.Verify(p => p.Save(It.IsAny<Venda>()), Times.Once());
            retornoVenda.Id.Should().BeGreaterThan(0);
            retornoVenda.Id.Should().Be(_vendaefaultWithId.Id);
        }

        [Test]
        public void Update_Deveria_atualizar_Os_Dados_Da_Venda()
        {
            //Arrange
            _vendaRepositoryMockObject.Setup(p => p.Update(It.IsAny<Venda>()));

            //Action
            Action actionVendaUpdate = () => { _vendaService.Update(_vendaefaultWithId); };

            //Assert
            actionVendaUpdate.Should().NotThrow<Exception>();
            _vendaRepositoryMockObject.Verify(p => p.Update(It.IsAny<Venda>()), Times.Once());
            _vendaRepositoryMockObject.Verify(p => p.Update(It.IsAny<Venda>()));
        }

        [Test]
        public void Get_Deveria_Retornar_Uma_Venda()
        {
            //Arrange
            _vendaRepositoryMockObject.Setup(p => p.Get(It.IsAny<long>())).Returns(_vendaefaultWithId);

            //Action 
            Venda retornoVenda = _vendaService.Get(_vendaefaultWithId.Id);

            //Assert
            _vendaRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()));
            _vendaRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()), Times.Once());
            retornoVenda.Id.Should().BeGreaterThan(0);
            retornoVenda.Id.Should().Be(_vendaefaultWithId.Id);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_As_Vendas()
        {
            //Arrange
            IList<Venda> _vendaDefaultList = VendaObjectMother.DefaultListVendas;

            _vendaRepositoryMockObject.Setup(p => p.GetAll()).Returns(_vendaDefaultList);

            //Action
            var resultVendas = _vendaService.GetAll();

            //Assert
            _vendaRepositoryMockObject.Verify(x => x.GetAll());
            resultVendas.Should().NotBeEmpty();
            resultVendas.Should().HaveCount(3);
        }

        [Test]
        public void Delete_Deveria_Deletar_Uma_Venda()
        {
            //Arrange
            _vendaRepositoryMockObject.Setup(x => x.Delete(_vendaefaultWithId));

            //Action
            Action vendaDeleteAction = () => _vendaService.Delete(_vendaefaultWithId);

            //Assert
            vendaDeleteAction.Should().NotThrow<Exception>();
            _vendaRepositoryMockObject.Verify(x => x.Delete(_vendaefaultWithId), Times.Once());
            _vendaRepositoryMockObject.Verify(x => x.Delete(_vendaefaultWithId));
        }
    }
}

