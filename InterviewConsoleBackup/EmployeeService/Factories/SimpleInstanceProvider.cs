using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System;
using System.ServiceModel.Channels;

namespace EmployeeService.Factories
{   
    /// <summary>
    /// A simple implementation of <see cref="IInstanceProvider"/> that provides service instances
    /// using a delegate-based factory method. Useful for enabling custom dependency injection in WCF.
    /// </summary>
    public class SimpleInstanceProvider : IInstanceProvider
    {
        private readonly Func<object> _creator;
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleInstanceProvider"/> class with a given factory delegate.
        /// </summary>
        /// <param name="creator">A delegate used to create instances of the service.</param>
        public SimpleInstanceProvider(Func<object> creator)
        {
            _creator = creator;
        }
        /// <summary>
        /// Returns a service object given the specified <see cref="InstanceContext"/>.
        /// </summary>
        /// <param name="instanceContext">The current <see cref="InstanceContext"/>.</param>
        /// <returns>A service object.</returns>
        public object GetInstance(InstanceContext instanceContext) => _creator();
        /// <summary>
        /// Returns a service object given the specified <see cref="InstanceContext"/> and <see cref="Message"/>.
        /// </summary>
        /// <param name="instanceContext">The current <see cref="InstanceContext"/>.</param>
        /// <param name="message">The message that triggered the service instance creation.</param>
        /// <returns>A service object.</returns>
        public object GetInstance(InstanceContext instanceContext, Message message)=>_creator();

        /// <summary>
        /// Called when an instance of the service is to be recycled. This implementation does nothing.
        /// </summary>
        /// <param name="instanceContext">The current <see cref="InstanceContext"/>.</param>
        /// <param name="instance">The service instance to release.</param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance) { }
    }
}