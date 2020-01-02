using System;
using TodoApi.Service;

namespace TodoApi.StudyGoods
{
    public class SellGoods : ISellGoodsInterface
    {
        public string SellGoodsToSb(int soldGoodsId, int quantity, int buyer)
        {
            var theSqlCommand = TransactionService.TheSqlCommand;

            theSqlCommand.CommandText = 
                "INSERT INTO study_sold (goods_id,quantity,buyer_id) VALUES (@soldGoodsId, @quantity, @buyer)";
            theSqlCommand.Parameters.AddWithValue("@soldGoodsId", soldGoodsId);
            theSqlCommand.Parameters.AddWithValue("@quantity", quantity);
            theSqlCommand.Parameters.AddWithValue("@buyer", buyer);

            theSqlCommand.ExecuteNonQuery();

            /*
             throw new Exception("try an exception");
             transaction will rollback if exception occurs
             */
            return $"sold goods: {soldGoodsId} * {quantity}, buyer is {buyer}";
        }
    }
}