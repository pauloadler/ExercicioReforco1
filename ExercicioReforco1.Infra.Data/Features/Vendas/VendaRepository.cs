using System;
using System.Collections.Generic;
using System.Data;
using ExercicioReforco1.Domain.Features.Produtos;
using ExercicioReforco1.Domain.Features.Vendas;

namespace ExercicioReforco1.Infra.Data.Features.Vendas
{
    public class VendaRepository : IVendaRepository
    {
        #region QUERIES

        private const string SqlInsereVenda =
            @"INSERT INTO Venda
                (produto_id, 
                 quantidade, 
                 lucro)
            VALUES
                (@produto_id, 
                 @quantidade, 
                 @lucro)";

        private const string SqlEditaVenda =
            @"UPDATE Venda
                SET
                    produto_id = @produto_id, 
                    quantidade = @quantidade, 
                    lucro = @lucro
                WHERE id_venda = {0}id_venda";

        private const string SqlSelecionaTodasVendas =
           @"SELECT 
                Venda.id_venda,
                Venda.produto_id, 
                Venda.quantidade,     
                Venda.lucro,
                produto.nome, 
                produto.preco_venda, 
                produto.preco_custo, 
                produto.disponibilidade, 
                produto.data_fabricacao, 
                produto.data_validade
            FROM
                Venda
            INNER JOIN Produto ON Venda.produto_id = Produto.id_produto";

        private const string SqlSelecionaVendaPorId =
           @"SELECT 
                Venda.id_venda,
                Venda.produto_id, 
                Venda.quantidade,     
                Venda.lucro,
                produto.nome, 
                produto.preco_venda, 
                produto.preco_custo, 
                produto.disponibilidade, 
                produto.data_fabricacao, 
                produto.data_validade
            FROM
                Venda
            INNER JOIN Produto ON Venda.produto_id = Produto.id_produto
            WHERE id_venda = {0}id_venda";

        private const string SqlDeletaVenda =
           @"DELETE FROM Venda
                WHERE id_venda = {0}id_venda";


        #endregion QUERIES

        public Venda Save(Venda venda)
        {
            venda.Id = Db.Insert(SqlInsereVenda, GetParametros(venda));

            return venda;
        }

        public void Update(Venda venda)
        {
            Db.Update(SqlEditaVenda, GetParametros(venda));
        }

        public void Delete(Venda venda)
        {
            var parms = new Dictionary<string, object> { { "id_venda", venda.Id } };

            Db.Delete(SqlDeletaVenda, parms);
        }

        public Venda Get(long id)
        {
            var parms = new Dictionary<string, object> { { "id_venda", id } };

            return Db.Get(SqlSelecionaVendaPorId, Converter, parms);
        }

        public IList<Venda> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodasVendas, Converter);
        }
        
        private Dictionary<string, object> GetParametros(Venda venda)
        {
            return new Dictionary<string, object>
            {
                { "id_venda", venda.Id },
                { "produto_id", venda.ProdutoVenda.Id },
                { "quantidade", venda.Quantidade },
                { "lucro", venda.Lucro}
            };
        }
        
        private static Func<IDataReader, Venda> Converter = reader =>
        
         new Venda(
             new Produto()
                 {
                     Id = Convert.ToInt64(reader["produto_id"]),
                     Nome = Convert.ToString(reader["nome"]),
                     PrecoVenda = Convert.ToDouble(reader["preco_venda"]),
                     PrecoCusto = Convert.ToDouble(reader["preco_custo"]),
                     Disponibilidade = Convert.ToBoolean(reader["disponibilidade"]),
                     DataFabricacao = Convert.ToDateTime(reader["data_fabricacao"]),
                     DataValidade = Convert.ToDateTime(reader["data_validade"])
                 }
             )
         {
             Id = Convert.ToInt64(reader["id_venda"]),
             Quantidade = Convert.ToInt32(reader["quantidade"])
         };
    }
}
