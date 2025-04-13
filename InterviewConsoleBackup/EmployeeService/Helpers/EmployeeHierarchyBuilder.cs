using EmployeeService.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeService.Helpers
{ 
    /// <summary>
    /// Provides functionality to build a hierarchical structure of employees based on manager-subordinate relationships.
    /// </summary>
    public class EmployeeHierarchyBuilder : IEmployeeHierarchyBuilder
    {
        /// <summary>
        /// Builds a hierarchical tree of employees based on their manager-subordinate relationships.
        /// </summary>
        /// <param name="all">A list of all employees.</param>
        /// <param name="rootId">The ID of the root employee.</param>
        /// <returns>An <see cref="EmployeeModel"/> representing the root and their subordinates, or null if not found.</returns>
        public EmployeeModel BuildTree(List<EmployeeModel> all, int rootId)
        {
            var lookup = all.ToDictionary(e => e.ID);

            all.Where(e => e.ManagerID is int managerId && lookup.ContainsKey(managerId))
               .ToList()
               .ForEach(e => lookup[e.ManagerID.Value].Employees.Add(e));

            return lookup.TryGetValue(rootId, out var root) ? root : null;
        }
    }
}