using ExercicioReforco1.Common.Tests.Base;
using ExercicioReforco1.Common.Tests.Features.Vendas;
using ExercicioReforco1.Domain.Features.Vendas;
using ExercicioReforco1.Infra.Data.Features.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco1.Infra.Data.Tests.Features.Vendas
{
    [TestFixture]
    public class VendaRepositoryTests
    {
        VendaRepository _vendaRepository;
        Venda _vendaDefault;

        [SetUp]
        public void VendaRepositoryTestsTestSetUp()
        {
           BaseSqlTest.SeedDeleteDatabase();
           BaseSqlTest.SeedInsertDatabase();

            _vendaRepository = new VendaRepository();
            _vendaDefault = VendaObjectMother.Default;
        }

        [Test]
        public void Save_Deveria_Gravar_Uma_Nova_Venda()
        {
            //Action-Arrange
            Venda resultVenda = _vendaRepository.Save(_vendaDefault);

            //Assert
            Venda resultGet = _vendaRepository.Get(resultVenda.Id);

            resultVenda.Should().NotBeNull();
            resultVenda.ProdutoVenda.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultVenda.Id);
        }

        [Test]
        public void Update_Deveria_Alterar_Os_Dados_De_Venda()
        {
            //Arrange
            Venda vendaResult = _vendaRepository.Save(_vendaDefault);
            vendaResult.Quantidade = 15;

            //Action
            _vendaRepository.Update(vendaResult);

            //Assert
            Venda resultGet = _vendaRepository.Get(vendaResult.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(vendaResult.Id);
            resultGet.Quantidade.Should().Be(15);
        }

        [Test]
        public void Get_Deveria_Retornar_Uma_Venda()
        {
            //Arrange
            Venda resultVenda = _vendaRepository.Save(_vendaDefault);

            //Action
            Venda resultGet = _vendaRepository.Get(resultVenda.Id);

            //Assert
            resultVenda.ProdutoVenda.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultVenda);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_As_Vendas()
        {
            //Arrange 
            Venda resultVenda = _vendaRepository.Save(_vendaDefault);

            //Action
            IList<Venda> resultGetAll = _vendaRepository.GetAll();

            //Assert
            var ultimaVenda = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(2);
            ultimaVenda.Should().Equals(_vendaDefault);
        }

        [Test]
        public void Delete_Deveria_Deletar_Uma_Venda()
        {
            //Arrange 
            Venda resultVenda = _vendaRepository.Save(_vendaDefault);

            //Action
            _vendaRepository.Delete(resultVenda);

            //Assert
            Venda resultGet = _vendaRepository.Get(resultVenda.Id);
            IList<Venda> resultGetAll = _vendaRepository.GetAll();

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
