> .net版本: 3.1
> 远端数据库版本: SQL Server 2014

#### 使用方法

```
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // 修改 DB 连接信息
            var connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

            // Provide the query string with a parameter placeholder.
            var queryString =
                "SELECT * from dbo.config "
                + "WHERE id > @configID "
                + "ORDER BY id DESC;";

            // Specify the parameter value.
            var paramValue = 2;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (var connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@configID", paramValue);

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadLine();
            }
        }
    }
}
```
