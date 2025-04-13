using System.Data.SqlClient;

namespace EmployeeService.Data
{
    /// <summary>
    /// Defines a contract for creating SQL database connections.
    /// </summary>
    public interface IDbConnection
    {
        /// <summary>
        /// Creates and opens a new SQL connection using the specified configuration.
        /// </summary>
        /// <returns>An open <see cref="SqlConnection"/> instance.</returns>
        SqlConnection CreateConnection();

    }
}