using ExercicioReforco1.Application.Features.Vendas;
using ExercicioReforco1.Common.Tests.Base;
using ExercicioReforco1.Common.Tests.Features.Vendas;
using ExercicioReforco1.Domain.Features.Vendas;
using ExercicioReforco1.Infra.Data.Features.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco1.Integration.Tests.Features.Vendas
{
    [TestFixture]
    public class VendaSystemTest
    {
        IVendaRepository _vendaRepository;
        VendaService _vendaService;
        Venda _vendaDefault;

        [SetUp]
        public void ProdutoSystemTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _vendaRepository = new VendaRepository();
            _vendaService = new VendaService(_vendaRepository);
            _vendaDefault = VendaObjectMother.Default;
        }

        [Test]
        public void Sistema_Deveria_Salvar_Um_Novo_Produto_E_Retornar_Do_Banco()
        {
            //Action-Arrange
            Venda resultVenda = _vendaService.Add(_vendaDefault);

            //Assert
            resultVenda.Should().NotBeNull();
            resultVenda.Id.Should().NotBe(0);

            Venda resultGet = _vendaService.Get(resultVenda.Id);
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultVenda);
        }

        [Test]
        public void Sistema_Deveria_Alterar_Um_Produto_Pelo_Id()
        {
            //Arrange
            Venda resultVenda = _vendaService.Add(_vendaDefault);
            resultVenda.Quantidade = 15;

            //Action 
            _vendaService.Update(resultVenda);

            //Assert
            Venda resultGet = _vendaService.Get(resultVenda.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultVenda.Id);
            resultGet.Quantidade.Should().Be(15);
        }

        [Test]
        public void Sistema_Deveria_Buscar_Um_Produto_Pelo_Id()
        {
            //Arrange 
            Venda resultVenda = _vendaService.Add(_vendaDefault);

            //Action
            Venda resultGet = _vendaService.Get(resultVenda.Id);

            //Assert
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultVenda.Id);
            resultGet.Should().Equals(resultVenda);
        }

        [Test]
        public void Sistema_Deveria_Buscar_Todos_Os_Produto()
        {
            //Arrange 
            Venda resultVenda = _vendaService.Add(_vendaDefault);

            //Action
            IList<Venda> resultGetAll = _vendaService.GetAll();

            //Assert
            var ultimaVenda = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(2);
            ultimaVenda.Should().Equals(_vendaDefault);
        }

        [Test]
        public void Sistema_Deveria_Deletar_Um_Produto_Pelo_Id()
        {
            Venda resultVenda = _vendaService.Add(_vendaDefault);

            //Action
            _vendaService.Delete(resultVenda);

            //Assert
            Venda resultGet = _vendaService.Get(resultVenda.Id);
            IList<Venda> resultGetAll = _vendaService.GetAll();

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
