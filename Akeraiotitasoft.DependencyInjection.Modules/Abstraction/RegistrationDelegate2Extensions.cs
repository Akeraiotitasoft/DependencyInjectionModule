using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Modules.Abstraction
{
    public static class RegistrationDelegate2Extensions
    {
        public static void Add(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, object instance)
        {
            registractionDelegate2(serviceCollection, serviceType, instance, null, ServiceLifetime.Singleton, null, false);
        }

        public static void Add(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Type implementationType, ServiceLifetime serviceLifetime)
        {
            registractionDelegate2(serviceCollection, serviceType, null, implementationType, serviceLifetime, null, false);
        }

        public static void Add(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Func<IServiceProvider, object> factory, ServiceLifetime serviceLifetime)
        {
            registractionDelegate2(serviceCollection, serviceType, null, null, serviceLifetime, factory, false);
        }

        public static void AddSingleton(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, object instance)
        {
            registractionDelegate2(serviceCollection, serviceType, instance, null, ServiceLifetime.Singleton, null, false);
        }

        public static void AddSingleton(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Type implementationType)
        {
            registractionDelegate2(serviceCollection, serviceType, null, implementationType, ServiceLifetime.Singleton, null, false);
        }

        public static void AddSingleton(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Func<IServiceProvider, object> factory)
        {
            registractionDelegate2(serviceCollection, serviceType, null, null, ServiceLifetime.Singleton, factory, false);
        }

        public static void AddTransient(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Type implementationType)
        {
            registractionDelegate2(serviceCollection, serviceType, null, implementationType, ServiceLifetime.Transient, null, false);
        }

        public static void AddTransient(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Func<IServiceProvider, object> factory)
        {
            registractionDelegate2(serviceCollection, serviceType, null, null, ServiceLifetime.Transient, factory, false);
        }

        public static void AddScoped(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Type implementationType)
        {
            registractionDelegate2(serviceCollection, serviceType, null, implementationType, ServiceLifetime.Scoped, null, false);
        }

        public static void AddScoped(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Func<IServiceProvider, object> factory)
        {
            registractionDelegate2(serviceCollection, serviceType, null, null, ServiceLifetime.Scoped, factory, false);
        }

        public static void TryAdd(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, object instance)
        {
            registractionDelegate2(serviceCollection, serviceType, instance, null, ServiceLifetime.Singleton, null, true);
        }

        public static void TryAdd(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Type implementationType, ServiceLifetime serviceLifetime)
        {
            registractionDelegate2(serviceCollection, serviceType, null, implementationType, serviceLifetime, null, true);
        }

        public static void TryAdd(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Func<IServiceProvider, object> factory, ServiceLifetime serviceLifetime)
        {
            registractionDelegate2(serviceCollection, serviceType, null, null, serviceLifetime, factory, true);
        }

        public static void TryAddSingleton(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, object instance)
        {
            registractionDelegate2(serviceCollection, serviceType, instance, null, ServiceLifetime.Singleton, null, true);
        }

        public static void TryAddSingleton(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Type implementationType)
        {
            registractionDelegate2(serviceCollection, serviceType, null, implementationType, ServiceLifetime.Singleton, null, true);
        }

        public static void TryAddSingleton(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Func<IServiceProvider, object> factory)
        {
            registractionDelegate2(serviceCollection, serviceType, null, null, ServiceLifetime.Singleton, factory, true);
        }

        public static void TryAddTransient(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Type implementationType)
        {
            registractionDelegate2(serviceCollection, serviceType, null, implementationType, ServiceLifetime.Transient, null, true);
        }

        public static void TryAddTransient(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Func<IServiceProvider, object> factory)
        {
            registractionDelegate2(serviceCollection, serviceType, null, null, ServiceLifetime.Transient, factory, true);
        }

        public static void TryAddScoped(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Type implementationType)
        {
            registractionDelegate2(serviceCollection, serviceType, null, implementationType, ServiceLifetime.Scoped, null, true);
        }

        public static void TryAddScoped(this RegistrationDelegate2 registractionDelegate2, IServiceCollection serviceCollection, Type serviceType, Func<IServiceProvider, object> factory)
        {
            registractionDelegate2(serviceCollection, serviceType, null, null, ServiceLifetime.Scoped, factory, true);
        }
    }
}
