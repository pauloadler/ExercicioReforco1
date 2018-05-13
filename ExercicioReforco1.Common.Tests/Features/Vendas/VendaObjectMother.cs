using ExercicioReforco1.Common.Tests.Features.Produtos;
using ExercicioReforco1.Domain.Features.Vendas;
using System.Collections.Generic;

namespace ExercicioReforco1.Common.Tests.Features.Vendas
{
    public class VendaObjectMother
    {
        public static Venda Default
        {
            get
            {
                return new Venda(ProdutoObjectMother.DefaultWithId)
                {
                    Quantidade = 5
                };
            }
        }

        public static Venda DefaultWithId
        {
            get
            {
                return new Venda(ProdutoObjectMother.DefaultWithId)
                {
                    Id = 1,
                    Quantidade = 5
                };
            }
        }

        public static IList<Venda> DefaultListVendas
        {
            get
            {
                IList<Venda> allVendas = new List<Venda>();

                allVendas.Add(new Venda(ProdutoObjectMother.DefaultWithId)
                {
                    Id = 1,
                    Quantidade = 5
                });

                allVendas.Add(new Venda(ProdutoObjectMother.DefaultWithId)
                {
                    Id = 2,
                    Quantidade = 3
                });

                allVendas.Add(new Venda(ProdutoObjectMother.DefaultWithId)
                {
                    Id = 3,
                    Quantidade = 4
                });

                return allVendas;
            }
        }

        public static Venda ProdutoSemEstoque
        {
            get
            {
                return new Venda(ProdutoObjectMother.SemEstoque)
                {
                    Quantidade = 5,
                    Lucro = 2.00
                };
            }
        }

        public static Venda ProdutoForaDataValidade
        {
            get
            {
                return new Venda(ProdutoObjectMother.ForaDataValidade)
                {
                    Quantidade = 5,
                    Lucro = 2.00
                };
            }
        }

        public static Venda QuantidadeZero
        {
            get
            {
                return new Venda(ProdutoObjectMother.SemEstoque)
                {
                    Quantidade = 0,
                    Lucro = 2.00
                };
            }
        }
    }
}
