using Akeraiotitasoft.DependencyInjection.Modules;
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
        public static RegistrationDelegate Delegate
        {
            get; private set;
        }

        public static RegistrationDelegate Current
        {
            get;set;
        }


        static DefaultRegistrationDelegate()
        {
            Current = Delegate = (serviceCollection, serviceType, instance, implementationType, serviceLifetime, factory, tryRegister) =>
            {
                if (tryRegister)
                {
                    if (serviceCollection.Any(x => x.ServiceType == serviceType))
                    {
                        return;
                    }
                }

                if (instance != null && factory == null && serviceLifetime == ServiceLifetime.Singleton)
                {
                    serviceCollection.Add(new ServiceDescriptor(serviceType, instance));
                }
                else if (instance == null && factory == null && implementationType != null)
                {
                    serviceCollection.Add(new ServiceDescriptor(serviceType, implementationType, serviceLifetime));
                }
                else if (factory != null)
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
