using InterviewConsole.ServiceReference1;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
namespace InterviewConsole
{
    class Program
    {   
        static void Main(string[] args)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress("http://localhost:64014/EmployeeService.svc");
            var client = new EmployeeServiceClient(binding, endpoint); // автоматично згенерований проксі
            var employeeId = 1; 
            var enable=1;
            client.EnableEmployee(employeeId, enable);
            client.Close();
            Console.ReadLine();

        }

        //private static void PrintEmployeeTree(EmployeeModel employee, int indent = 0)
        //{
        //    Console.WriteLine($"{new string(' ', indent * 2)}- {employee.Name} (ID: {employee.ID})");

        //    employee.Employees?
        //        .OrderBy(e => e.Name) 
        //        .ToList()
        //        .ForEach(sub => PrintEmployeeTree(sub, indent + 1));
        //}
        //private static void ExportEmployeeToJson(EmployeeModel employee, string filePath)
        //{
        //    var json = JsonConvert.SerializeObject(employee, Formatting.Indented);
        //    File.WriteAllText("employee.json", json);
        //}
    }
}
