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
    public class TestTable1Repository : IRepository<TestTable1>
    {
        private string connectionString;
        public TestTable1Repository(IConfiguration configuration)
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
        public void Add(TestTable1 item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO TestTable1 (name,email) VALUES(@Name, @Email)", item);
            }
        }
        public IEnumerable<TestTable1> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<TestTable1>("SELECT * from TestTable1");
            }
        }
        public TestTable1 FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<TestTable1>("SELECT * from TestTable1 where id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM TestTable1 where id=@Id", new { Id = id });
            }
        }
        public void Update(TestTable1 item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE TestTable1 SET name = @Name, email= @Email WHERE id = @Id", item);
            }
        }
    }
}
