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
    public class SimpleUserRepository : IRepository<SimpleUser>
    {
	private string connectionString;
	public SimpleUserRepository(IConfiguration configuration)
	{
	    connectionString = "";
	}
	internal IDbConnection Connection
	{
	    get
	    {
		Console.Write(connectionString);
		return new NpgsqlConnection("");
	    }
	}
	public void Add(SimpleUser item)
	{
	    using (IDbConnection dbConnection = Connection)
	    {
		dbConnection.Open();
		dbConnection.Execute("INSERT INTO simpleuser (name,email) VALUES(@Name, @Email)",item);
	    }
	}
	public IEnumerable<SimpleUser> FindAll()
	{
	    using (IDbConnection dbConnection = Connection)
	    {
		dbConnection.Open();
		return dbConnection.Query<SimpleUser>("SELECT * from simpleuser");
	    }
	}
	public SimpleUser FindByID(int id)
	{
	    using (IDbConnection dbConnection = Connection)
	    {
		dbConnection.Open();
		return dbConnection.Query<SimpleUser>("SELECT * from simpleuser where id = @Id", new { Id = id}).FirstOrDefault();
	    }
	}
	public void Remove(int id)
	{
	    using (IDbConnection dbConnection = Connection)
	    {
		dbConnection.Open();
		dbConnection.Execute("DELETE FROM simpleuser where id=@Id",new {Id = id});
	    }
	}
	public void Update(SimpleUser item)
	{
	    using (IDbConnection dbConnection = Connection)
	    {
		dbConnection.Open();
		dbConnection.Query("UPDATE simpleuser SET name = @Name, email= @Email WHERE id = @Id", item);
	    }
	}
    }
}
