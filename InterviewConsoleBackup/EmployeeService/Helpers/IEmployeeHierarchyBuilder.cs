using EmployeeService.Models;
using System.Collections.Generic;

namespace EmployeeService.Helpers
{
    /// <summary>
    /// Defines a contract for building a hierarchical tree structure of employees.
    /// </summary>
    public interface IEmployeeHierarchyBuilder
    {
        /// <summary>
        /// Builds a hierarchical structure of employees based on manager-subordinate relationships.
        /// </summary>
        /// <param name="all">A list of all employees.</param>
        /// <param name="rootId">The ID of the root employee from which the hierarchy should start.</param>
        /// <returns>
        /// An <see cref="EmployeeModel"/> representing the root employee and their subordinates,
        /// or null if the root employee is not found.
        /// </returns>
        EmployeeModel BuildTree(List<EmployeeModel> all, int rootId);
    }
}