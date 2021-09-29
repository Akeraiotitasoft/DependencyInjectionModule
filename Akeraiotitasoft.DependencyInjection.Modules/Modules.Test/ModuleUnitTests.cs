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
        public void LoadModulesEx()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.LoadModulesEx();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            IA a = serviceProvider.GetRequiredService<IA>();
            IB b = serviceProvider.GetRequiredService<IB>();
            int c = a.MathOperation(1, 2);
            string message = b.GetMessage();
            Assert.AreEqual(3, c);
            Assert.AreEqual("Hello World!", message);
        }

        [Test]
        public void LoadModulesEx_Override()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.LoadModulesEx((Type interfaceType, Type concreteType, ServiceLifetime serviceLifetime, IServiceCollection serviceCollection) =>
            {
                Type typeToRegister = null;
                if (interfaceType == typeof(IA))
                {
                    typeToRegister = typeof(MockA2);
                }
                else
                {
                    typeToRegister = concreteType;
                }

                DefaultRegistrationDelegate.Delegate(interfaceType, typeToRegister, serviceLifetime, serviceCollection);
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
        public void LoadModulesEx2()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.LoadModulesEx2();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            IA a = serviceProvider.GetRequiredService<IA>();
            IB b = serviceProvider.GetRequiredService<IB>();
            int c = a.MathOperation(1, 2);
            string message = b.GetMessage();
            Assert.AreEqual(3, c);
            Assert.AreEqual("Hello World!", message);
        }

        [Test]
        public void LoadModulesEx2_Override()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            List<Func<RegistrationOverrideSwitch, bool>> overrides = new List<Func<RegistrationOverrideSwitch, bool>>();
            overrides.Add(x => x.Case(typeof(IA), typeof(MockA2)));
            overrides.Add(x => x.Default());

            serviceCollection.LoadModulesEx2((IServiceCollection serviceCollection, Type serviceType, object instance, Type implementationType, ServiceLifetime serviceLifetime, Func<IServiceProvider, object> factory, bool tryRegister) =>
            {
                RegistrationOverrideSwitch registrationOverrideSwitch = new RegistrationOverrideSwitch(DefaultRegistrationDelegate2.Delegate, serviceCollection, serviceType, instance, implementationType, serviceLifetime, factory, tryRegister);
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
        public void LoadModulesEx2_Override2()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.LoadModulesEx2((IServiceCollection serviceCollection, Type serviceType, object instance, Type implementationType, ServiceLifetime serviceLifetime, Func<IServiceProvider, object> factory, bool tryRegister) =>
            {
                RegistrationOverrideSwitch registrationOverrideSwitch = new RegistrationOverrideSwitch(DefaultRegistrationDelegate2.Delegate, serviceCollection, serviceType, instance, implementationType, serviceLifetime, factory, tryRegister);
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
    }
}