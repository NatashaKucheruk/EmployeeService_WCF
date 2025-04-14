namespace EmployeeService.Exceptions
{  
     /// <summary>
    /// Provides constant exception messages used across the application.
    /// </summary>
    public static class ExceptionStrings
    {
        /// Messages displayed
        public static string DatabaseErrorRetrievingEmployees = "Database error occurred while retrieving employees.",
                             DatabaseErrorEnableEmployee = "Database error occurred while enable employee\r\n.",
                             DatabaseIsEmpty = "Database is empty",
                             FailedEnableEmployee = "Failed to enable employee: ",
                             UnexpectedError=   "An unexpected error occurred: ",
                             EmployeeWithIDError="Employee with ID {0} not found.";
    }
}
