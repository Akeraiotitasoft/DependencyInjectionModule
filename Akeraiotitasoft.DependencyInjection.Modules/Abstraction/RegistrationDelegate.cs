using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Modules
{
    public delegate void RegistrationDelegate(IServiceCollection serviceCollection, Type serviceType, object instance, Type implementationType, ServiceLifetime serviceLifetime, Func<IServiceProvider, object> factory, bool tryRegister);
}
