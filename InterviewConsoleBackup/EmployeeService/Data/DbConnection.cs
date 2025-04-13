using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeService.Data
{
    /// <summary>
    /// Provides a concrete implementation for creating SQL database connections.
    /// </summary>
    public class DbConnection : IDbConnection
    {
        private readonly string _connectionString;
        /// <summary>
        /// Initializes a new instance of the <see cref="DbConnection"/> class
        /// using a predefined connection string to connect to the local SQL Server database.
        /// </summary>
        public DbConnection()
        {
            _connectionString =
                // Alternatively, use configuration:
                //"Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Database=Test;";
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        /// <summary>
        /// Creates and opens a new SQL connection using the configured connection string.
        /// </summary>
        /// <returns>A new open <see cref="SqlConnection"/> instance.</returns>
        public SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}