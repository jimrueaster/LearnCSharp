using System;
using TodoApi.StudyGoods;

namespace TodoApi.Service
{
    public class SellGoodsTransactionService : TransactionService
    {
        public string SellGoodsToSbOfService(int goodId, int quantity, int buyer)
        {
            var transaction = TheSqlConnection.BeginTransaction();
            TheSqlCommand.Transaction = transaction;

            var result = "";
            try
            {
                ISellGoodsInterface sellGoods = new SellGoods();
                result = sellGoods.SellGoodsToSb(goodId, quantity, buyer);

                // Attempt to commit the transaction.
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine("  Message: {0}", ex.Message);
            
                // Attempt to roll back the transaction.
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    // This catch block will handle any errors that may have occurred
                    // on the server that would cause the rollback to fail, such as
                    // a closed connection.
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }

            return result;
        }
    }
}