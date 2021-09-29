using Akeraiotitasoft.DependencyInjection.Modules.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Modules
{
    public class DefaultRegistrationDelegate
    {
        private static RegistrationDelegate _registrationDelegate;
        
        public static RegistrationDelegate Delegate
        {
            get
            {
                return _registrationDelegate;
            }
        }

        static DefaultRegistrationDelegate()
        {
            _registrationDelegate = (serviceType, implementationType, serviceLifetime, serviceCollection) =>
            {
                serviceCollection.Add(new ServiceDescriptor(serviceType, implementationType, serviceLifetime));
            };
        }
    }
}
