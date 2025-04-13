using EmployeeService.Models;
using System.Collections.Generic;

namespace EmployeeService.Repository
{
    /// <summary>
    /// Defines methods for accessing and manipulating employee data in a data source.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Retrieves all employees from the data source.
        /// </summary>
        /// <returns>A list of <see cref="EmployeeModel"/> objects representing all employees.</returns>
        List<EmployeeModel> GetAllEmployees();

        /// <summary>
        /// Enables an employee by updating their status in the data source.
        /// </summary>
        /// <param name="id">The ID of the employee to enable.</param>
        void EnableEmployee(int id);
    }
}