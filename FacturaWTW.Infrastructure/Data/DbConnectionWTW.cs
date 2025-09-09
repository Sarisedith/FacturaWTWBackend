using System.Data;
using Microsoft.Data.SqlClient;

namespace FacturaWTW.Infrastructure.Data
{
    public class DbConnectionWTW
    {
        private readonly string _connectionString;
        public DbConnectionWTW(string connectionString) => _connectionString = connectionString;
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
