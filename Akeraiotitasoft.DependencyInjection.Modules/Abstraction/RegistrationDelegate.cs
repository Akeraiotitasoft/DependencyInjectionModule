using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Modules.Abstraction
{
    public delegate void RegistrationDelegate(Type interfaceType, Type concreteType, ServiceLifetime serviceLifetime, IServiceCollection serviceCollection);
}
