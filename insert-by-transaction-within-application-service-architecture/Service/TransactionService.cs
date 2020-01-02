using System;
using Microsoft.Data.SqlClient;

namespace TodoApi.Service
{
    public class TransactionService
    {
        [ThreadStatic] public static SqlCommand TheSqlCommand;

        [ThreadStatic] public static SqlConnection TheSqlConnection;

        public TransactionService()
        {
            // todo config this connectionString when deploy 
            var connectionString = "Server=db_ip_address;Database=db_name;User Id=username;Password=password;";

            TheSqlConnection = new SqlConnection(connectionString);
            TheSqlConnection.Open();
            TheSqlCommand = TheSqlConnection.CreateCommand();
            TheSqlCommand.Connection = TheSqlConnection;

            // var threadSqlCommand = new ThreadLocal<SqlCommand>(() => command);
            // var threadSqlTransaction = new ThreadLocal<SqlTransaction>(() => transaction);
            
        }
    }
}