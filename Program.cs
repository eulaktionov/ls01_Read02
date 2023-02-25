using Microsoft.Data.SqlClient;
using static System.Console;

WriteLine("ExecuteReader");

SqlConnection connection = null;
SqlDataReader reader = null;

try
{
    string connectionString =
        @"Data Source=(localdb)\MSSQLLocalDB;" +
        "Initial Catalog=Library01;";
    connection = new SqlConnection(connectionString);
    connection.Open();

    string commandText =
        "select * " +
        "from Authors";
    SqlCommand command =
        new SqlCommand(commandText, connection);
    reader = command.ExecuteReader();
    ShowData();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    if (reader != null)
    {
        reader.Close();
    }
    if(connection is not null)
    {
        connection.Close();
    }
    ReadKey();
}

void ShowData()
{
    for(int i = 0; i < reader.FieldCount; i++)
    {
        Write($"{reader.GetName(i), 20}");
    }
    WriteLine();
    while(reader.Read())
    {
        for(int i = 0; i < reader.FieldCount; i++)
        {
            Write($"{reader[i],20}");
        }
        WriteLine();
    }
}

