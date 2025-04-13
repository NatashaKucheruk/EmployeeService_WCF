using System.ServiceModel;
using System;
using System.ServiceModel.Activation;

namespace EmployeeService.Factories
{   
    /// <summary>
    /// A custom service host factory that enables dependency injection
    /// for the <see cref="EmployeeService.Service"/> class by injecting its dependencies manually.
    /// </summary>

    public class EmployeeServiceFactory : ServiceHostFactory
    {
        /// <summary>
        /// Creates a <see cref="ServiceHost"/> for the specified service type and base addresses,
        /// and applies a custom dependency injection behavior.
        /// </summary>
        /// <param name="serviceType">The type of the service to host.</param>
        /// <param name="baseAddresses">An array of base addresses for the service.</param>
        /// <returns>A configured <see cref="ServiceHost"/> instance with DI behavior.
        /// </returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            // Ручне створення залежностей
            var dbConnection = new Data.DbConnection();
            var repository = new Repository.EmployeeRepository(dbConnection);
            var builder = new Helpers.EmployeeHierarchyBuilder();
            var service = new Service(repository, builder);
            var host = new ServiceHost(typeof(Service), baseAddresses);
            host.Description.Behaviors.Add(
                new DependencyInjectionServiceBehavior(() => service));

            return host;
        }
    }
}