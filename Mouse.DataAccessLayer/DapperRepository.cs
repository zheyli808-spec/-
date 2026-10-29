using Dapper;
using Microsoft.IdentityModel.Protocols;
using Mouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Mouse.DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T>
        where T : class, IDomainObject
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public DapperRepository(string tableName = "Mice")
        {
            _connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["MouseDatabase"].ConnectionString;

            _tableName = tableName;
        }

        public void Add(T entity)
        {
            using (var connection =
                new SqlConnection(_connectionString))
            {
                var properties = typeof(T).GetProperties()
                    .Where(p => p.Name != "Id"
                             && p.Name != "ID");

                var columns = string.Join(", ",
                    properties.Select(p => p.Name));

                var parameters = string.Join(", ",
                    properties.Select(p => "@" + p.Name));

                string sql = $"INSERT INTO {_tableName} " +
                    $"({columns}) VALUES ({parameters})";

                connection.Execute(sql, entity);
            }
        }

        public void Delete(T entity)
        {
            using (var connection =
                new SqlConnection(_connectionString))
            {
                string sql =
                    $"DELETE FROM {_tableName} WHERE Id = @Id";

                connection.Execute(sql, new { Id = entity.ID });
            }
        }

        public List<T> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT COUNT(*) FROM Mice";
                int count = connection.ExecuteScalar<int>(sql);

                Console.WriteLine("Записей в базе Dapper: " + count);

                sql = "SELECT * FROM Mice";
                return connection.Query<T>(sql).ToList();
            }
        }

        public T GetById(int id)
        {
            using (var connection =
                new SqlConnection(_connectionString))
            {
                string sql =
                    $"SELECT * FROM {_tableName} WHERE Id = @Id";

                return connection.QueryFirstOrDefault<T>(
                    sql, new { Id = id });
            }
        }


            public void Update(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var properties = typeof(T).GetProperties()
                    .Where(p => p.Name != "Id" && p.Name != "ID");

                var setValues = string.Join(", ",
                    properties.Select(p => p.Name + " = @" + p.Name));

                string sql = $"UPDATE {_tableName} SET {setValues} WHERE Id = @Id";

                var parameters = new DynamicParameters(entity);
                parameters.Add("Id", entity.ID);

                connection.Execute(sql, parameters);
            }
        }
                

    }
}
