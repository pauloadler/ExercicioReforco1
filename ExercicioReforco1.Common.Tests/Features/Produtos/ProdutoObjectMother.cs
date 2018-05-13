using ExercicioReforco1.Domain.Features.Produtos;
using System;
using System.Collections.Generic;

namespace ExercicioReforco1.Common.Tests.Features.Produtos
{
    public class ProdutoObjectMother
    {
        public static Produto Default
        {
            get
            {
                return new Produto()
                {
                    Nome = "Nome de Teste",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(30)
                };
            }
        }

        public static IList<Produto> DefaultListProdutos
        {
            get
            {
                IList<Produto> allProdutos = new List<Produto>();

                allProdutos.Add(new Produto()
                {
                    Id = 1,
                    Nome = "Nome de Teste 1",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(30)
                });

                allProdutos.Add(new Produto()
                {
                    Id = 1,
                    Nome = "Nome de Teste 2",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(30)
                });

                allProdutos.Add(new Produto()
                {
                    Id = 1,
                    Nome = "Nome de Teste 3",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(30)
                });

                return allProdutos;
            }
        }

        public static Produto DefaultWithId
        {
            get
            {
                return new Produto()
                {
                    Id = 1,
                    Nome = "Nome de Teste",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(30)
                };
            }
        }

        public static Produto DefaultUpdate
        {
            get
            {
                return new Produto()
                {
                    Id = 1,
                    Nome = "Nome de Teste Update",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(30)
                };
            }
        }

        public static Produto ProdutoNomeNulo
        {
            get
            {
                return new Produto()
                {
                    Nome = "",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(30)
                };
            }
        }
        
        public static Produto NomeMinimoCaracteres
        {
            get
            {
                return new Produto()
                {
                    Nome = "Tes",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(30)
                };
            }
        }

        public static Produto PrecoCustoMaiorPrecoVenda
        {
            get
            {
                return new Produto()
                {
                    Nome = "Nome de Teste",
                    PrecoVenda = 8.00,
                    PrecoCusto = 10.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(30)
                };
            }
        }

        public static Produto DataValidadeMenorDataFabricacao
        {
            get
            {
                return new Produto()
                {
                    Nome = "Tes",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(-1)
                };
            }
        }

        public static Produto SemEstoque
        {
            get
            {
                return new Produto()
                {
                    Nome = "Tes",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = false,
                    DataFabricacao = DateTime.Now,
                    DataValidade = DateTime.Now.AddDays(-1)
                };
            }
        }

        public static Produto ForaDataValidade
        {
            get
            {
                return new Produto()
                {
                    Nome = "Tes",
                    PrecoVenda = 10.00,
                    PrecoCusto = 8.00,
                    Disponibilidade = true,
                    DataFabricacao = DateTime.Now.AddDays(-30),
                    DataValidade = DateTime.Now.AddDays(-10)
                };
            }
        }
    }
}
