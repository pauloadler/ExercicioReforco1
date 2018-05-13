using System;
using System.Collections.Generic;
using System.Data;
using ExercicioReforco1.Domain.Features.Produtos;
using ExercicioReforco1.Infra;

namespace ExercicioReforco1.Infra.Data.Features.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        #region QUERIES

        private const string SqlInsereProduto =
            @"INSERT INTO Produto
                (nome, 
                preco_venda, 
                preco_custo, 
                disponibilidade, 
                data_fabricacao, 
                data_validade)
            VALUES
                (@nome, 
                @preco_venda, 
                @preco_custo, 
                @disponibilidade, 
                @data_fabricacao, 
                @data_validade)";

        private const string SqlEditaProduto =
            @"UPDATE Produto
                SET
                    nome = @nome, 
                    preco_venda = @preco_venda, 
                    preco_custo = @preco_custo, 
                    disponibilidade = @disponibilidade, 
                    data_fabricacao = @data_fabricacao,
                    data_validade = @data_validade
                WHERE id_produto = {0}id_produto";

        private const string SqlSelecionaTodosProdutos =
           @"SELECT 
                id_produto,
                nome, 
                preco_venda, 
                preco_custo, 
                disponibilidade, 
                data_fabricacao, 
                data_validade
            FROM
                Produto";

        private const string SqlSelecionaProdutoPorId =
           @"SELECT
                id_produto,
                nome, 
                preco_venda, 
                preco_custo, 
                disponibilidade, 
                data_fabricacao,
                data_validade
            FROM
                Produto
            WHERE id_produto = {0}id_produto";

        private const string SqlDeletaProduto =
           @"DELETE FROM Produto
                WHERE id_produto = {0}id_produto";


        #endregion QUERIES

        public Produto Save(Produto produto)
        {
            produto.Id = Db.Insert(SqlInsereProduto, GetParametros(produto));

            return produto;
        }

        public void Update(Produto produto)
        {
            Db.Update(SqlEditaProduto, GetParametros(produto));
        }

        public void Delete(Produto produto)
        {
            var parms = new Dictionary<string, object> { { "id_produto", produto.Id } };

            Db.Delete(SqlDeletaProduto, parms);
        }

        public Produto Get(long id)
        {
            var parms = new Dictionary<string, object> { { "id_produto", id } };

            return Db.Get(SqlSelecionaProdutoPorId, Converter, parms);
        }

        public IList<Produto> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodosProdutos, Converter);
        }

        private Dictionary<string, object> GetParametros(Produto produto)
        {
            return new Dictionary<string, object>
            {
                { "id_produto", produto.Id },
                { "nome", produto.Nome },
                { "preco_venda", produto.PrecoVenda },
                { "preco_custo", produto.PrecoCusto },
                { "disponibilidade", produto.Disponibilidade },
                { "data_fabricacao", produto.DataFabricacao },
                { "data_validade", produto.DataValidade },
            };
        }

        private static Func<IDataReader, Produto> Converter = reader =>
         new Produto
         {
             Id = Convert.ToInt64(reader["id_produto"]),
             Nome = Convert.ToString(reader["nome"]),
             PrecoVenda = Convert.ToDouble(reader["preco_venda"]),
             PrecoCusto = Convert.ToDouble(reader["preco_custo"]),
             Disponibilidade = Convert.ToBoolean(reader["disponibilidade"]),
             DataFabricacao = Convert.ToDateTime(reader["data_fabricacao"]),
             DataValidade = Convert.ToDateTime(reader["data_validade"])
         };
    }
}
