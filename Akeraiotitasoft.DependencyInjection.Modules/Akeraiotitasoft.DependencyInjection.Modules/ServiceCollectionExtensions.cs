﻿using Akeraiotitasoft.DependencyInjection.Modules.Abstraction;
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
        {
            var serviceCollectionModule = (IServiceCollectionModule)Activator.CreateInstance(typeof(TModule));
            serviceCollectionModule.ConfigureServices(serviceCollection);
        }

        public static void LoadModuleEx<TModule>(this IServiceCollection serviceCollection, RegistrationDelegate registrationDelegate)
            where TModule : IServiceCollectionModuleEx
        {
            var serviceCollectionModule = (IServiceCollectionModuleEx)Activator.CreateInstance(typeof(TModule));
            serviceCollectionModule.ConfigureServices(serviceCollection, registrationDelegate);
        }

        public static void LoadModules(this IServiceCollection serviceCollection)
            => serviceCollection.LoadModules(x => true);

        public static void LoadModules(this IServiceCollection serviceCollection, Func<IServiceCollectionModule, bool> serviceCollectionModuleFilter)
        {
            // Get all IServiceCollectionModule implementations
            var servicesConfigurationModuleTypes =
                AppDomain.CurrentDomain.GetAssemblies()
                         .SelectMany(assembly => assembly.GetLoadableTypes())
                         .Where(type => typeof(IServiceCollectionModule).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                         .Where(type => type.GetConstructor(Type.EmptyTypes) != null)
                         .ToList();

            foreach (var type in servicesConfigurationModuleTypes)
            {
                var serviceCollectionModule = (IServiceCollectionModule)Activator.CreateInstance(type);
                if (serviceCollectionModuleFilter(serviceCollectionModule))
                {
                    serviceCollectionModule.ConfigureServices(serviceCollection);
                }
            }
        }

        public static void LoadModulesEx(this IServiceCollection serviceCollection)
            => serviceCollection.LoadModulesEx(x => true, DefaultRegistrationDelegate.Delegate);

        public static void LoadModulesEx(this IServiceCollection serviceCollection, Func<IServiceCollectionModule, bool> serviceCollectionModuleFilter)
            => serviceCollection.LoadModulesEx(serviceCollectionModuleFilter, DefaultRegistrationDelegate.Delegate);

        public static void LoadModulesEx(this IServiceCollection serviceCollection, RegistrationDelegate registrationDelegate)
            => serviceCollection.LoadModulesEx(x => true, registrationDelegate);

        public static void LoadModulesEx(this IServiceCollection serviceCollection, Func<IServiceCollectionModule, bool> serviceCollectionModuleFilter, RegistrationDelegate registrationDelegate)
        {
            // Get all IServiceCollectionModule implementations
            var servicesConfigurationModuleTypes =
                AppDomain.CurrentDomain.GetAssemblies()
                         .SelectMany(assembly => assembly.GetLoadableTypes())
                         .Where(type => typeof(IServiceCollectionModuleEx).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                         .Where(type => type.GetConstructor(Type.EmptyTypes) != null)
                         .ToList();

            foreach (var type in servicesConfigurationModuleTypes)
            {
                var serviceCollectionModule = (IServiceCollectionModuleEx)Activator.CreateInstance(type);
                if (serviceCollectionModuleFilter(serviceCollectionModule))
                {
                    serviceCollectionModule.ConfigureServices(serviceCollection, registrationDelegate);
                }
            }
        }
    }
}
