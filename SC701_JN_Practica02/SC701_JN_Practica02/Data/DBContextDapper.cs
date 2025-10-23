using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SC701_JN_Practica02.Data
{
    public class DBContextDapper
    {
        private readonly IConfiguration _configuration; 
        private readonly string _connectionString;

        public DBContextDapper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Practica2") 
                ?? throw new InvalidOperationException("Connection string 'Practica2' not found.");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}