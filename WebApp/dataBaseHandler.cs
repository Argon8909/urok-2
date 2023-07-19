using Npgsql;
using System.Collections.Generic;
namespace WebApp;



public static class DataBaseHandler
{
    private static int Insert(string sql)
    {
        var db = GetConnection();
        using var cmd = new NpgsqlCommand(sql, db);
        //cmd.Parameters.AddWithValue("p", "Hello world");
        return cmd.ExecuteNonQuery();
    }

    private static List<List<string>> Select(string sql)
    {
       List<List<string>> result = new List<List<string>>();

        var db = GetConnection();
        using var cmd = new NpgsqlCommand(sql, db);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var columsCount = reader.FieldCount;
            
            var vue = reader.GetString(column);
        }

        return result;
    }

    private static NpgsqlConnection GetConnection()
    {
        var connString = "Host=localhost;Username=postgres;Password=123;Database=postgres";
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connString);
        var dataSource = dataSourceBuilder.Build();

        return dataSource.OpenConnection();
    }
}