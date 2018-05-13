using ExercicioReforco1.Common.Tests.Features.Vendas;
using ExercicioReforco1.Domain.Features.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace ExercicioReforco1.Domain.Tests.Features.Vendas
{
    [TestFixture]
    public class VendaDomainTest
    {

        [SetUp]
        public void VendaDomainTestSetUp()
        {
        }
        
        [Test]
        public void Venda_Nao_Deve_Possuir_Um_Produto_Sem_Estoque()
        {
            //Arrange
            Venda vendaProdutoSemEstoque = VendaObjectMother.ProdutoSemEstoque;

            //Action
            Action actionValidaProduto = vendaProdutoSemEstoque.ValidaProduto;

            //Assert
            actionValidaProduto.Should().Throw<ProdutoSemDisponibilidadeException>();
        }
        
        [Test]
        public void Venda_Nao_Deve_Possuir_Um_Produto_Fora_Da_Data_De_Validade()
        {
            //Arrange
            Venda vendaProdutoForaValidade = VendaObjectMother.ProdutoForaDataValidade;

            //Action
            Action actionValidaProduto = vendaProdutoForaValidade.ValidaProduto;

            //Assert
            actionValidaProduto.Should().Throw<ProdutoForaDaDataDeValidadeException>();
        }

        [Test]
        public void Venda_Nao_Deve_Ter_Quantidade_Menor_Que_Zero()
        {
            //Arrange
            Venda vendaQuantidadeZero = VendaObjectMother.QuantidadeZero;

            //Action
            Action actionValidaQuantidade = vendaQuantidadeZero.ValidaQuantidade;

            //Assert
            actionValidaQuantidade.Should().Throw<QuantidadeZeroException>();
        }

        [Test]
        public void Venda_CalculoLucro_Deveria_Calcular_O_Lucro_Corretamente()
        {

            Venda vendaDefault = VendaObjectMother.Default;
            vendaDefault.Id = 1;

            //Arrange-Action
            vendaDefault.calculoLucro();

            //Assert
            vendaDefault.Lucro.Should().NotBe(0);
            vendaDefault.Lucro.Should().Be(2);
        }
    }
}
