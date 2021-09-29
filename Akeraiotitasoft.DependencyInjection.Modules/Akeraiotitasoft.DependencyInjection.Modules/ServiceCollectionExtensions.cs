using Akeraiotitasoft.DependencyInjection.Modules;
using Akeraiotitasoft.DependencyInjection.Modules.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Akeraiotitasoft.DependencyInjection.Modules
{
    public static class ServiceCollectionExtensions
    {
        public static void LoadModule<TModule>(this IServiceCollection serviceCollection)
            where TModule : IServiceCollectionModule
        => LoadModule<TModule>(serviceCollection, DefaultRegistrationDelegate.Current);

        public static void LoadModule<TModule>(this IServiceCollection serviceCollection, RegistrationDelegate registrationDelegate)
            where TModule : IServiceCollectionModule
        {
            var serviceCollectionModule = (IServiceCollectionModule)Activator.CreateInstance(typeof(TModule));
            ServiceCollectionModuleContext context = new ServiceCollectionModuleContext();
            context.ServiceCollection = serviceCollection;
            context.RegistrationDelegate = registrationDelegate;
            serviceCollectionModule.ConfigureServices(context);
        }

        public static void LoadModules(this IServiceCollection serviceCollection)
            => serviceCollection.LoadModules(x => true, DefaultRegistrationDelegate.Current);

        public static void LoadModules(this IServiceCollection serviceCollection, Func<IServiceCollectionModule, bool> serviceCollectionModuleFilter)
            => serviceCollection.LoadModules(serviceCollectionModuleFilter, DefaultRegistrationDelegate.Current);

        public static void LoadModules(this IServiceCollection serviceCollection, RegistrationDelegate registrationDelegate)
            => serviceCollection.LoadModules(x => true, registrationDelegate);

        public static void LoadModules(this IServiceCollection serviceCollection, Func<IServiceCollectionModule, bool> serviceCollectionModuleFilter, RegistrationDelegate registrationDelegate)
        {
            // Get all IServiceCollectionModule implementations
            var servicesConfigurationModuleTypes =
                AppDomain.CurrentDomain.GetAssemblies()
                         .SelectMany(assembly => assembly.GetLoadableTypes())
                         .Where(type => typeof(IServiceCollectionModule).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                         .Where(type => type.GetConstructor(Type.EmptyTypes) != null)
                         .ToList();

            ServiceCollectionModuleContext context = new ServiceCollectionModuleContext();
            context.ServiceCollection = serviceCollection;
            context.RegistrationDelegate = registrationDelegate;

            foreach (var type in servicesConfigurationModuleTypes)
            {
                var serviceCollectionModule = (IServiceCollectionModule)Activator.CreateInstance(type);
                if (serviceCollectionModuleFilter(serviceCollectionModule))
                {
                    serviceCollectionModule.ConfigureServices(context);
                }
            }
        }
    }
}
