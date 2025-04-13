using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System;
using System.ServiceModel.Description;
using System.Linq;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
//-------------------------------------------------------------//
//Since this is a test task, I implemented manual dependency injection
//due to the size of the project.
//If it weren't a test task, I would have used Ninject, as it's
//more suitable for medium and large-scale projects.
//--------------------------------------------------------------//
namespace EmployeeService.Factories
{
    /// <summary>
    /// Custom WCF service behavior that enables dependency injection by providing a custom instance provider.
    /// </summary>
    public class DependencyInjectionServiceBehavior: IServiceBehavior
    {
        /// <summary>
        /// Delegate used to create service instances with dependencies.
        /// </summary>
        private readonly Func<object> _instanceCreator;
        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyInjectionServiceBehavior"/> class
        /// with the specified instance creation function.
        /// </summary>
        /// <param name="instanceCreator">A function that returns a service instance.
        /// </param>
        public DependencyInjectionServiceBehavior(Func<object> instanceCreator)
        {
         _instanceCreator = instanceCreator;
        }
        /// <summary>
        /// Adds custom binding parameters to the service endpoint. Not used in this implementation.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host.</param>
        /// <param name="endpoints">The collection of service endpoints.</param>
        /// <param name="bindingParameters">The collection of binding parameters.
        /// </param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            // No binding parameters required.
        }

        /// <summary>
        /// Applies the custom instance provider to the service's dispatch behavior,
        /// enabling dependency injection at runtime.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="host">The service host.</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase host)
        {
            foreach (var dispatcher in host.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                foreach (var endpoint in dispatcher.Endpoints)
                {
                   endpoint.DispatchRuntime.InstanceProvider = new SimpleInstanceProvider(_instanceCreator);
                }
            }
        }
        /// <summary>
        /// Validates the service description and host prior to runtime. Not used in this implementation.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host.</param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            // No validation required.
        }
    }
}
