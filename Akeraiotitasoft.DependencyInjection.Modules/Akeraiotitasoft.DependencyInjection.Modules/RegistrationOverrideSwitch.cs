using Akeraiotitasoft.DependencyInjection.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Modules
{
    public class RegistrationOverrideSwitch
    {
        private RegistrationDelegate _registrationDelegate;
        private IServiceCollection _serviceCollection;
        private Type _serviceType;
        private object _instance;
        private Type _implementationType;
        private ServiceLifetime _serviceLifetime;
        private Func<IServiceProvider, object> _factory;
        private bool _tryRegister;
        private bool _overrideRan;

        public RegistrationOverrideSwitch(RegistrationDelegate registrationDelegate, IServiceCollection serviceCollection, Type serviceType, object instance, Type implementationType, ServiceLifetime serviceLifetime, Func<IServiceProvider, object> factory, bool tryRegister)
        {
            _registrationDelegate = registrationDelegate;
            _serviceCollection = serviceCollection;
            _serviceType = serviceType;
            _instance = instance;
            _implementationType = implementationType;
            _serviceLifetime = serviceLifetime;
            _factory = factory;
            _tryRegister = tryRegister;
        }

        public RegistrationOverrideSwitch(IServiceCollection serviceCollection, Type serviceType, object instance, Type implementationType, ServiceLifetime serviceLifetime, Func<IServiceProvider, object> factory, bool tryRegister)
            : this(DefaultRegistrationDelegate.Delegate, serviceCollection, serviceType, instance, implementationType, serviceLifetime, factory, tryRegister)
        {
        }

        public bool Case(Type serviceType, object instance)
        {
            if (!_overrideRan)
            {
                if (_serviceType == serviceType)
                {
                    if (_serviceLifetime != ServiceLifetime.Singleton)
                    {
                        throw new ServiceCollectionModuleException("Incorrect service lifetime");
                    }

                    _registrationDelegate(_serviceCollection, _serviceType, instance, null, ServiceLifetime.Singleton, null, _tryRegister);
                    _overrideRan = true;
                }
            }
            return _overrideRan;
        }

        public bool Case(Type serviceType, Type implementationType)
        {
            if (!_overrideRan)
            {
                if (_serviceType == serviceType)
                {
                    _registrationDelegate(_serviceCollection, _serviceType, null, implementationType, _serviceLifetime, null, _tryRegister);
                    _overrideRan = true;
                }
            }
            return _overrideRan;
        }

        public bool Case(Type serviceType, Func<IServiceProvider, object> factory)
        {
            if (!_overrideRan)
            {
                if (_serviceType == serviceType)
                {
                    _registrationDelegate(_serviceCollection, _serviceType, null, null, _serviceLifetime, factory, _tryRegister);
                    _overrideRan = true;
                }
            }
            return _overrideRan;
        }

        public bool Default()
        {
            if (!_overrideRan)
            {
                _registrationDelegate(_serviceCollection, _serviceType, _instance, _implementationType, _serviceLifetime, _factory, _tryRegister);
                _overrideRan = true;
            }
            return _overrideRan;
        }
    }
}
