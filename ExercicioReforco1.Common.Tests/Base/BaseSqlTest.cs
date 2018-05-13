using ExercicioReforco1.Infra;

namespace ExercicioReforco1.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_VENDA_TABLE = "DELETE FROM [dbo].[Venda]" +
                                                    "DBCC CHECKIDENT ('Venda', RESEED, 0)";

        private const string RECREATE_PRODUTO_TABLE = "DELETE FROM [dbo].[Produto]" +
                                                       "DBCC CHECKIDENT ('Produto', RESEED, 0)";

        private const string INSERT = @"
                        DECLARE @dateNowMoreDays DateTime;
                        DECLARE @produtoId INT

                        SELECT  @dateNowMoreDays = DATEADD(day, 30, GETDATE())

                        INSERT INTO Produto(nome, 
                                            preco_venda, 
                                            preco_custo, 
                                            disponibilidade, 
                                            data_fabricacao, 
                                            data_validade)

                        VALUES('Produto Teste', 10.00, 8.00, 1, GETDATE(), @dateNowMoreDays)

                        SET @produtoId = @@IDENTITY

                        INSERT INTO Venda (produto_id, quantidade, lucro)         
			            VALUES (@produtoId, 2, 2.00);";

        public static void SeedDeleteDatabase()
        {
            Db.Update(RECREATE_VENDA_TABLE);
            Db.Update(RECREATE_PRODUTO_TABLE);
        }

        public static void SeedInsertDatabase()
        {
            Db.Update(INSERT);
        }
    }
}
