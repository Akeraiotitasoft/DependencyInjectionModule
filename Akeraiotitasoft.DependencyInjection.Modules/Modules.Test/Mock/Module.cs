using Akeraiotitasoft.DependencyInjection.Modules.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Test.Mock
{
    public class Module : IServiceCollectionModuleEx2
    {
        public void ConfigureServices(IServiceCollection serviceCollection, RegistrationDelegate2 registrationDelegate)
        {
            registrationDelegate.AddSingleton(serviceCollection, typeof(IA), typeof(MockA));
            registrationDelegate.AddSingleton(serviceCollection, typeof(IB), typeof(MockB));
        }

        public void ConfigureServices(IServiceCollection serviceCollection, RegistrationDelegate registrationDelegate)
        {
            registrationDelegate(typeof(IA), typeof(MockA), ServiceLifetime.Singleton, serviceCollection);
            registrationDelegate(typeof(IB), typeof(MockB), ServiceLifetime.Singleton, serviceCollection);
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(IA), typeof(MockA));
            serviceCollection.AddSingleton(typeof(IB), typeof(MockB));
        }
    }
}
