using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Modules
{
    public static class ContextExtensions
    {
        public static void Add(this IServiceCollectionModuleContext context, Type serviceType, ServiceLifetime serviceLifetime)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, serviceType, serviceLifetime, null, false);
        }

        public static void Add(this IServiceCollectionModuleContext context, Type serviceType, object instance)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, instance, null, ServiceLifetime.Singleton, null, false);
        }

        public static void Add(this IServiceCollectionModuleContext context, Type serviceType, Type implementationType, ServiceLifetime serviceLifetime)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, implementationType, serviceLifetime, null, false);
        }

        public static void Add(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, object> factory, ServiceLifetime serviceLifetime)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, serviceLifetime, factory, false);
        }

        public static void AddSingleton(this IServiceCollectionModuleContext context, Type serviceType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, serviceType, ServiceLifetime.Singleton, null, false);
        }

        public static void AddSingleton(this IServiceCollectionModuleContext context, Type serviceType, object instance)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, instance, null, ServiceLifetime.Singleton, null, false);
        }

        public static void AddSingleton(this IServiceCollectionModuleContext context, Type serviceType, Type implementationType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, implementationType, ServiceLifetime.Singleton, null, false);
        }

        public static void AddSingleton(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, object> factory)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Singleton, factory, false);
        }

        public static void AddSingleton<TService>(this IServiceCollectionModuleContext context)
            where TService : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TService), ServiceLifetime.Singleton, null, false);
        }

        public static void AddSingleton<TService>(this IServiceCollectionModuleContext context, TService instance)
            where TService : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), instance, null, ServiceLifetime.Singleton, null, false);
        }

        public static void AddSingleton<TService, TImplementation>(this IServiceCollectionModuleContext context)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TImplementation), ServiceLifetime.Singleton, null, false);
        }

        public static void AddSingleton<TService, TImplementation>(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, TImplementation> factory)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Singleton, factory, false);
        }

        public static void AddTransient(this IServiceCollectionModuleContext context, Type serviceType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, serviceType, ServiceLifetime.Transient, null, false);
        }

        public static void AddTransient(this IServiceCollectionModuleContext context, Type serviceType, Type implementationType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, implementationType, ServiceLifetime.Transient, null, false);
        }

        public static void AddTransient(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, object> factory)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Transient, factory, false);
        }

        public static void AddTransient<TService>(this IServiceCollectionModuleContext context)
            where TService : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TService), ServiceLifetime.Transient, null, false);
        }

        public static void AddTransient<TService, TImplementation>(this IServiceCollectionModuleContext context)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TImplementation), ServiceLifetime.Transient, null, false);
        }

        public static void AddTransient<TService, TImplementation>(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, TImplementation> factory)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Transient, factory, false);
        }

        public static void AddScoped(this IServiceCollectionModuleContext context, Type serviceType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, serviceType, ServiceLifetime.Scoped, null, false);
        }

        public static void AddScoped(this IServiceCollectionModuleContext context, Type serviceType, Type implementationType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, implementationType, ServiceLifetime.Scoped, null, false);
        }

        public static void AddScoped(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, object> factory)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Scoped, factory, false);
        }

        public static void AddScoped<TService>(this IServiceCollectionModuleContext context)
            where TService : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TService), ServiceLifetime.Scoped, null, false);
        }

        public static void AddScoped<TService, TImplementation>(this IServiceCollectionModuleContext context)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TImplementation), ServiceLifetime.Scoped, null, false);
        }

        public static void AddScoped<TService, TImplementation>(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, TImplementation> factory)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Scoped, factory, false);
        }

        public static void TryAdd(this IServiceCollectionModuleContext context, Type serviceType, ServiceLifetime serviceLifetime)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, serviceType, serviceLifetime, null, true);
        }

        public static void TryAdd(this IServiceCollectionModuleContext context, Type serviceType, object instance)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, instance, null, ServiceLifetime.Singleton, null, true);
        }

        public static void TryAdd(this IServiceCollectionModuleContext context, Type serviceType, Type implementationType, ServiceLifetime serviceLifetime)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, implementationType, serviceLifetime, null, true);
        }

        public static void TryAdd(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, object> factory, ServiceLifetime serviceLifetime)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, serviceLifetime, factory, true);
        }

        public static void TryAddSingleton(this IServiceCollectionModuleContext context, Type serviceType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, serviceType, ServiceLifetime.Singleton, null, true);
        }

        public static void TryAddSingleton(this IServiceCollectionModuleContext context, Type serviceType, object instance)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, instance, null, ServiceLifetime.Singleton, null, true);
        }

        public static void TryAddSingleton(this IServiceCollectionModuleContext context, Type serviceType, Type implementationType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, implementationType, ServiceLifetime.Singleton, null, true);
        }

        public static void TryAddSingleton(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, object> factory)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Singleton, factory, true);
        }

        public static void TryAddSingleton<TService>(this IServiceCollectionModuleContext context)
            where TService : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TService), ServiceLifetime.Singleton, null, true);
        }

        public static void TryAddSingleton<TService>(this IServiceCollectionModuleContext context, TService instance)
            where TService : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), instance, null, ServiceLifetime.Singleton, null, true);
        }

        public static void TryAddSingleton<TService, TImplementation>(this IServiceCollectionModuleContext context)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TImplementation), ServiceLifetime.Singleton, null, true);
        }

        public static void TryAddSingleton<TService, TImplementation>(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, TImplementation> factory)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Singleton, factory, true);
        }

        public static void TryAddTransient(this IServiceCollectionModuleContext context, Type serviceType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, serviceType, ServiceLifetime.Transient, null, true);
        }

        public static void TryAddTransient(this IServiceCollectionModuleContext context, Type serviceType, Type implementationType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, implementationType, ServiceLifetime.Transient, null, true);
        }

        public static void TryAddTransient(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, object> factory)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Transient, factory, true);
        }

        public static void TryAddTransient<TService>(this IServiceCollectionModuleContext context)
            where TService : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TService), ServiceLifetime.Transient, null, true);
        }

        public static void TryAddTransient<TService, TImplementation>(this IServiceCollectionModuleContext context)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TImplementation), ServiceLifetime.Transient, null, true);
        }

        public static void TryAddTransient<TService, TImplementation>(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, TImplementation> factory)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Transient, factory, true);
        }

        public static void TryAddScoped(this IServiceCollectionModuleContext context, Type serviceType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, serviceType, ServiceLifetime.Scoped, null, true);
        }

        public static void TryAddScoped(this IServiceCollectionModuleContext context, Type serviceType, Type implementationType)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, implementationType, ServiceLifetime.Scoped, null, true);
        }

        public static void TryAddScoped(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, object> factory)
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Scoped, factory, true);
        }

        public static void TryAddScoped<TService>(this IServiceCollectionModuleContext context)
            where TService : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TService), ServiceLifetime.Scoped, null, true);
        }

        public static void TryAddScoped<TService, TImplementation>(this IServiceCollectionModuleContext context)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, typeof(TService), null, typeof(TImplementation), ServiceLifetime.Scoped, null, true);
        }

        public static void TryAddScoped<TService, TImplementation>(this IServiceCollectionModuleContext context, Type serviceType, Func<IServiceProvider, TImplementation> factory)
            where TService : class
            where TImplementation : class
        {
            context.RegistrationDelegate(context.ServiceCollection, serviceType, null, null, ServiceLifetime.Scoped, factory, true);
        }
    }
}
