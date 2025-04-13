using EmployeeService.Exceptions;
using EmployeeService.Helpers;
using EmployeeService.Models;
using EmployeeService.Repository;
using System;
using System.ServiceModel;

namespace EmployeeService
{
    /// <summary>
    /// WCF service implementation for managing and retrieving employee data,
    /// including hierarchical relationships and enabling employees.
    /// </summary>
    public class Service : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IEmployeeHierarchyBuilder _hierarchyBuilder;
        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class using the specified database access implementation.
        /// </summary>
        public Service(IEmployeeRepository repository, IEmployeeHierarchyBuilder hierarchyBuilder)
        {
            _repository = repository;
            _hierarchyBuilder = hierarchyBuilder;
        }
        /// <summary>
        /// Retrieves an employee by ID and builds a tree of their subordinates.
        /// </summary>
        /// <param name="id">The ID of the root employee.</param>
        /// <returns>An <see cref="EmployeeModel"/> containing the employee and their subordinates, or null if not found.
        /// </returns>
        public EmployeeModel GetEmployeeById(int id)
        {
            try
            {
                var employees = _repository.GetAllEmployees();
                if (employees == null || employees.Count == 0)
                    throw new FaultException(ExceptionStrings.DatabaseIsEmpty);
                 var employee = _hierarchyBuilder.BuildTree(employees, id);
                 if (employee == null)
                    throw new FaultException(String.Format(ExceptionStrings
                        .EmployeeWithIDError,id));
                 return employee;
            }
            catch (FaultException) 
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new FaultException(ExceptionStrings.UnexpectedError + ex.Message);
            }

        }

        /// <summary>
        /// Enables an employee by setting the "Enable" field to 1 in the database.
        /// </summary>
        /// <param name="id">The ID of the employee to enable.</param>
        /// <param name="enable">A flag to indicate whether to enable (currently ignored, always enables).
        /// </param>
        public void EnableEmployee(int id, int enable)
        {
            try
            {
                _repository.EnableEmployee(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ExceptionStrings.FailedEnableEmployee
                    + ex.Message);
            }
        }

       
    }

      
}