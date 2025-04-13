using EmployeeService.Data;
using EmployeeService.Exceptions;
using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeService.Repository
{
    /// <summary>
    /// Provides methods for accessing and manipulating employee data in the database.
    /// </summary>
    public class EmployeeRepository: IEmployeeRepository
    {
        /// <summary>
        /// Provides access to the database connection.
        /// </summary>
        private readonly IDbConnection _dataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class
        /// with the specified data access implementation.
        /// </summary>
        /// <param name="dataAccess">An object that provides access to the database connection.</param>
        public EmployeeRepository(IDbConnection dataAccess)
        {
            _dataAccess = dataAccess;
        }
        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        /// <returns>A list of <see cref="EmployeeModel"/> objects representing all employees.</returns>
        public List<EmployeeModel> GetAllEmployees()
        {
            var list = new List<EmployeeModel>();
            try
            {
               using (var conn = _dataAccess.CreateConnection())
                 using (var cmd = conn.CreateCommand())
                 {
                    cmd.CommandText = "SELECT * FROM Employee";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new EmployeeModel
                            {
                                ID = (int)reader["ID"],
                                Name = reader["Name"].ToString(),
                                ManagerID = reader["ManagerID"] as int?,
                                Enable = (bool)reader["Enable"]
                            });
                        }
                    }
                 }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException(ExceptionStrings
                    .DatabaseErrorRetrievingEmployees, ex);
            }
            return list;
        }

        /// <summary>
        /// Enables an employee by setting the "Enable" field to 1 in the database.
        /// </summary>
        /// <param name="id">The ID of the employee to enable.</param>
        /// <param name="enable">A flag to indicate whether to enable (currently ignored, always enables).
        /// </param>
        public void EnableEmployee(int id)
        {
            try
            {
                using (var conn = _dataAccess.CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Employee SET Enable = 1 WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw new ApplicationException(ExceptionStrings
                    .DatabaseErrorEnableEmployee, ex);
            }
        }
    }
}