using System.Collections.Generic;

namespace EmployeeService.Models
{
    /// <summary>
    /// Represents an employee in the organization with hierarchical relationships.
    /// </summary>
    public class EmployeeModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the ID of the employee's manager. Null if the employee has no manager.
        /// </summary>
        public int? ManagerID { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the employee is enabled.
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// Gets or sets the list of subordinate employees reporting to this employee.
        /// </summary>
        public List<EmployeeModel> Employees { get; set; } 
            =new List<EmployeeModel>();
    }
}