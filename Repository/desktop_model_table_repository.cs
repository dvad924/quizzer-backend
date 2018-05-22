using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using quizzer_backend.Models;

namespace quizzer_backend.Repository
{
    public class desktop_model_table_repository : IRepository<desktop_model_table>
    {
	private string connectionString;
	public desktop_model_table_repository(IConfiguration configuration)
	{
	    connectionString = "";
	}
	internal IDbConnection Connection
	{
	    get
	    {
		Console.Write(connectionString);
		return new NpgsqlConnection("User ID=samwise;Password=Iaintdroppingnoeavessir;Server=138.68.55.142;Database=quizzy;Pooling=true;");
	    }
	}
	public void Add(desktop_model_table item)
	{
	    using (IDbConnection dbConnection = Connection)
	    {
		dbConnection.Open();
		dbConnection.Execute("INSERT INTO desktop_model_table (display_name, review_score, price, cpu_model_name, cpu_benchmark, hd_model_name, hd_capacity_gb, hd_type, ram_gb, gpu_model_name, gpu_benchmark, features, url_to_product_page, model_number) VALUES(@display_name, @review_score, @price, @cpu_model_name, @cpu_benchmark, @hd_model_name, @hd_capacity_gb, @hd_type, @ram_gb, @gpu_model_name, @gpu_benchmark, @features, @url_to_product_page, @model_number)",item);
	    }
	}
	public IEnumerable<desktop_model_table> FindAll()
	{
	    using (IDbConnection dbConnection = Connection)
	    {
		dbConnection.Open();
		return dbConnection.Query<desktop_model_table>("SELECT * from desktop_model_table");
	    }
	}
	public desktop_model_table FindByID(int id)
	{
	    using (IDbConnection dbConnection = Connection)
	    {
		dbConnection.Open();
		return dbConnection.Query<desktop_model_table>("SELECT * from desktop_model_table where id = @Id", new { Id = id}).FirstOrDefault();
	    }
	}
	public void Remove(int id)
	{
	    using (IDbConnection dbConnection = Connection)
	    {
		dbConnection.Open();
		dbConnection.Execute("DELETE FROM desktop_model_table where id=@Id",new {Id = id});
	    }
	}
	public void Update(desktop_model_table item)
	{
	    using (IDbConnection dbConnection = Connection)
	    {
		dbConnection.Open();
		dbConnection.Query("UPDATE desktop_model_table SET name = @Name, email= @Email WHERE id = @Id", item);
	    }
	}
    }
}
