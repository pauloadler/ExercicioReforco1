using ExercicioReforco1.Common.Tests.Features.Produtos;
using ExercicioReforco1.Domain.Features.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace ExercicioReforco1.Domain.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoDomainTest
    {
        Produto _produtoDefault;
        Produto _produtoNomeNulo;
        Produto _produtoMinimoCaracteres;
        Produto _PrecoCustoMaiorPrecoVenda;
        Produto _DataValidadeMenorDataFabricacao;

        [SetUp]
        public void ProdutoDomainTestSetUp()
        {
            _produtoDefault = ProdutoObjectMother.Default;
            _produtoNomeNulo = ProdutoObjectMother.ProdutoNomeNulo;
            _produtoMinimoCaracteres = ProdutoObjectMother.NomeMinimoCaracteres;
            _PrecoCustoMaiorPrecoVenda = ProdutoObjectMother.PrecoCustoMaiorPrecoVenda;
            _DataValidadeMenorDataFabricacao = ProdutoObjectMother.DataValidadeMenorDataFabricacao;
        }

        [Test]
        public void Produto_Nao_Deveria_Possuir_Nome_Nulo()
        {
            //Action-Arrange
            Action produtoAction = _produtoNomeNulo.ValidaNome;

            //Assert
            produtoAction.Should().Throw<ProdutoNomeNuloOuVazioExcessao>();
        }

        [Test]
        public void Produto_Nao_Deveria_Possuir_Nome_Com_Numero_De_Caracteres_Abaixo_Do_Esperado()
        {
            //Action-Arrange
            Action produtoAction = _produtoMinimoCaracteres.ValidaNome;

            //Assert
            produtoAction.Should().Throw<Exception>();
        }

        [Test]
        public void Produto_Nao_Deveria_Possuir_Preco_De_Custo_Maior_Que_O_Preco_De_Venda()
        {
            //Action-Arrange
            Action produtoAction = _PrecoCustoMaiorPrecoVenda.ValidaPrecoCusto;

            //Assert
            produtoAction.Should().Throw<ProdutoPrecoCustoMaiorPrecoVendaExcessao>();
        }

        [Test]
        public void Produto_Nao_Deveria_Possuir_Data_De_Validade_Menor_Que_A_Data_De_Fabricacao()
        {
            //Action-Arrange
            Action produtoAction = _DataValidadeMenorDataFabricacao.ValidaDataValidade;

            //Assert
            produtoAction.Should().Throw<ProdutoDataValidadeMenorDataFabricacaoExcessao>();
        }
    }
}
