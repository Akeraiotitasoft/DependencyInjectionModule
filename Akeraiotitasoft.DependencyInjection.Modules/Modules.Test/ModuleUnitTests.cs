using Akeraiotitasoft.DependencyInjection.Modules;
using Microsoft.Extensions.DependencyInjection;
using Modules.Test.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Modules.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            DefaultRegistrationDelegate.Current = DefaultRegistrationDelegate.Delegate;
        }

        [Test]
        public void LoadModules()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.LoadModules();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            IA a = serviceProvider.GetRequiredService<IA>();
            IB b = serviceProvider.GetRequiredService<IB>();
            int c = a.MathOperation(1, 2);
            string message = b.GetMessage();
            Assert.AreEqual(3, c);
            Assert.AreEqual("Hello World!", message);
        }

        [Test]
        public void LoadModules_Override()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            List<Func<RegistrationOverrideSwitch, bool>> overrides = new List<Func<RegistrationOverrideSwitch, bool>>();
            overrides.Add(x => x.Case(typeof(IA), typeof(MockA2)));
            overrides.Add(x => x.Default());

            serviceCollection.LoadModules((IServiceCollection serviceCollection, Type serviceType, object instance, Type implementationType, ServiceLifetime serviceLifetime, Func<IServiceProvider, object> factory, bool tryRegister) =>
            {
                RegistrationOverrideSwitch registrationOverrideSwitch = new RegistrationOverrideSwitch(serviceCollection, serviceType, instance, implementationType, serviceLifetime, factory, tryRegister);
                foreach (var @override in overrides)
                {
                    if (@override(registrationOverrideSwitch))
                    {
                        break;
                    }
                }
            });
            var serviceProvider = serviceCollection.BuildServiceProvider();
            IA a = serviceProvider.GetRequiredService<IA>();
            IB b = serviceProvider.GetRequiredService<IB>();
            int c = a.MathOperation(1, 2);
            string message = b.GetMessage();
            Assert.AreEqual(4, c);
            Assert.AreEqual("Hello World!", message);
        }

        [Test]
        public void LoadModules_Override2()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.LoadModules((IServiceCollection serviceCollection, Type serviceType, object instance, Type implementationType, ServiceLifetime serviceLifetime, Func<IServiceProvider, object> factory, bool tryRegister) =>
            {
                RegistrationOverrideSwitch registrationOverrideSwitch = new RegistrationOverrideSwitch(serviceCollection, serviceType, instance, implementationType, serviceLifetime, factory, tryRegister);
                registrationOverrideSwitch.Case(typeof(IA), typeof(MockA2));
                registrationOverrideSwitch.Default();
            });
            var serviceProvider = serviceCollection.BuildServiceProvider();
            IA a = serviceProvider.GetRequiredService<IA>();
            IB b = serviceProvider.GetRequiredService<IB>();
            int c = a.MathOperation(1, 2);
            string message = b.GetMessage();
            Assert.AreEqual(4, c);
            Assert.AreEqual("Hello World!", message);
        }

        [Test]
        public void LoadModules_Override3()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            DefaultRegistrationDelegate.Current = 
                (IServiceCollection serviceCollection, Type serviceType, object instance, Type implementationType, ServiceLifetime serviceLifetime, Func<IServiceProvider, object> factory, bool tryRegister) =>
                {
                    RegistrationOverrideSwitch registrationOverrideSwitch = new RegistrationOverrideSwitch(serviceCollection, serviceType, instance, implementationType, serviceLifetime, factory, tryRegister);
                    registrationOverrideSwitch.Case(typeof(IA), typeof(MockA2));
                    registrationOverrideSwitch.Default();
                };

            serviceCollection.LoadModules();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            IA a = serviceProvider.GetRequiredService<IA>();
            IB b = serviceProvider.GetRequiredService<IB>();
            int c = a.MathOperation(1, 2);
            string message = b.GetMessage();
            Assert.AreEqual(4, c);
            Assert.AreEqual("Hello World!", message);
        }

        [Test]
        public void LoadModules_Override4()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            DefaultRegistrationDelegate.Current =
                (IServiceCollection serviceCollection, Type serviceType, object instance, Type implementationType, ServiceLifetime serviceLifetime, Func<IServiceProvider, object> factory, bool tryRegister) =>
                {
                    RegistrationOverrideSwitch registrationOverrideSwitch = new RegistrationOverrideSwitch(serviceCollection, serviceType, instance, implementationType, serviceLifetime, factory, tryRegister);
                    registrationOverrideSwitch.Case<IA, MockA2>();
                    registrationOverrideSwitch.Default();
                };

            serviceCollection.LoadModules();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            IA a = serviceProvider.GetRequiredService<IA>();
            IB b = serviceProvider.GetRequiredService<IB>();
            int c = a.MathOperation(1, 2);
            string message = b.GetMessage();
            Assert.AreEqual(4, c);
            Assert.AreEqual("Hello World!", message);
        }
    }
}