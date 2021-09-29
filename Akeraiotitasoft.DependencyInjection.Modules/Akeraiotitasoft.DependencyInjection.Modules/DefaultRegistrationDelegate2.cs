using Akeraiotitasoft.DependencyInjection.Modules.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Modules
{
    public class DefaultRegistrationDelegate2
    {
        private static RegistrationDelegate2 _registrationDelegate;

        public static RegistrationDelegate2 Delegate
        {
            get
            {
                return _registrationDelegate;
            }
        }

        static DefaultRegistrationDelegate2()
        {
            _registrationDelegate = (serviceCollection, serviceType, instance, implementationType, serviceLifetime, factory, tryRegister) =>
            {
                if (tryRegister)
                {
                    if (serviceCollection.Any(x => x.ServiceType == serviceType))
                    {
                        return;
                    }
                }

                if (instance != null && factory == null && implementationType == null && serviceLifetime == ServiceLifetime.Singleton)
                {
                    serviceCollection.Add(new ServiceDescriptor(serviceType, instance));
                }
                else if (instance == null && factory == null && implementationType != null)
                {
                    serviceCollection.Add(new ServiceDescriptor(serviceType, implementationType, serviceLifetime));
                }
                else if (factory != null && implementationType == null)
                {
                    serviceCollection.Add(new ServiceDescriptor(serviceType, factory, serviceLifetime));
                }
                else
                {
                    throw new ServiceCollectionModuleException();
                }
            };
        }
    }
}
