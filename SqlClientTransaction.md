
> 基于 SqlClient 的 transaction 写法

```
public static void LearnTransaction(string connectionString)
        {
           
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                // Start a local transaction.
                var transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText =
                        "INSERT INTO config (create_time,create_by,last_update,update_by,name,value) VALUES (CURRENT_TIMESTAMP,1,CURRENT_TIMESTAMP ,1,'HELLO_WORLD','1')";
                    command.ExecuteNonQuery();
                    command.CommandText =
                        "INSERT INTO config (create_time,create_by,last_update,update_by,name,value) VALUES (CURRENT_TIMESTAMP,1,CURRENT_TIMESTAMP ,1,'HELLO_C_Sharp','1')";
                    command.ExecuteNonQuery();

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
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
            }
        }
```
