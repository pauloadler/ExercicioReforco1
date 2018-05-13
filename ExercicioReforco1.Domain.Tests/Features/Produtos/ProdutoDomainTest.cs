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

        [SetUp]
        public void ProdutoDomainTestSetUp()
        {
            _produtoDefault = ProdutoObjectMother.Default;
        }

        [Test]
        public void Produto_Deveria_Passar_Nas_Validacoes_De_Nome()
        {
            //Arrange-Action
            Action actionValidaNome = _produtoDefault.ValidaNome;

            //Assert
            actionValidaNome.Should().NotThrow<ProdutoNomeNuloOuVazioExcessao>();
            actionValidaNome.Should().NotThrow<ProdutoNomeNaoAtendidoMinimoCaracteres>();
        }

        [Test]
        public void Produto_Deveria_Passar_Na_Validacao_De_Preco_De_Custo()
        {
            //Arrange-Action
            Action actionValidaPrecoCusto = _produtoDefault.ValidaPrecoCusto;

            //Assert
            actionValidaPrecoCusto.Should().NotThrow<ProdutoPrecoCustoMaiorPrecoVendaExcessao>();
        }

        [Test]
        public void Produto_Deveria_Passar_Na_Validacao_De_Data_De_Validade()
        {
            //Arrange-Action
            Action actionValidaDataValidade = _produtoDefault.ValidaDataValidade;

            //Assert
            actionValidaDataValidade.Should().NotThrow<ProdutoDataValidadeMenorDataFabricacaoExcessao>();
        }

        [Test]
        public void Produto_Nao_Deveria_Possuir_Nome_Nulo()
        {
            //Arrange
            Produto produtoNomeNulo = ProdutoObjectMother.ProdutoNomeNulo;

            //Action
            Action produtoAction = produtoNomeNulo.ValidaNome;

            //Assert
            produtoAction.Should().Throw<ProdutoNomeNuloOuVazioExcessao>();
        }

        [Test]
        public void Produto_Nao_Deveria_Possuir_Nome_Com_Numero_De_Caracteres_Abaixo_Do_Esperado()
        {
            //Arrange
            Produto produtoMinimoCaracteres = ProdutoObjectMother.NomeMinimoCaracteres;

            //Action
            Action produtoAction = produtoMinimoCaracteres.ValidaNome;

            //Assert
            produtoAction.Should().Throw<ProdutoNomeNaoAtendidoMinimoCaracteres>();
        }

        [Test]
        public void Produto_Nao_Deveria_Possuir_Preco_De_Custo_Maior_Que_O_Preco_De_Venda()
        {
            //Arrange
            Produto precoCustoMaiorPrecoVenda = ProdutoObjectMother.PrecoCustoMaiorPrecoVenda;

            //Action
            Action produtoAction = precoCustoMaiorPrecoVenda.ValidaPrecoCusto;

            //Assert
            produtoAction.Should().Throw<ProdutoPrecoCustoMaiorPrecoVendaExcessao>();
        }

        [Test]
        public void Produto_Nao_Deveria_Possuir_Data_De_Validade_Menor_Que_A_Data_De_Fabricacao()
        {
            //Arrange
            Produto dataValidadeMenorDataFabricacao = ProdutoObjectMother.DataValidadeMenorDataFabricacao;

            //Action
            Action produtoAction = dataValidadeMenorDataFabricacao.ValidaDataValidade;

            //Assert
            produtoAction.Should().Throw<ProdutoDataValidadeMenorDataFabricacaoExcessao>();
        }
    }
}
