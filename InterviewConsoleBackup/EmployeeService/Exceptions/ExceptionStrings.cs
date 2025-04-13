namespace EmployeeService.Exceptions
{
    public static class ExceptionStrings
    {
        public static string DatabaseErrorRetrievingEmployees = "Database error occurred while retrieving employees.",
                             DatabaseErrorEnableEmployee = "Database error occurred while enable employee\r\n.",
                             DatabaseIsEmpty = "Database is empty",
                             FailedEnableEmployee = "Failed to enable employee: ",
                             UnexpectedError=   "An unexpected error occurred: ",
                             EmployeeWithIDError="Employee with ID {0} not found.";
    }
}