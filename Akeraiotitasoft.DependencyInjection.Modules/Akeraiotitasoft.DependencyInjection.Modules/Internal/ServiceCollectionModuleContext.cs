using Akeraiotitasoft.DependencyInjection.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Modules.Internal
{
    internal class ServiceCollectionModuleContext : IServiceCollectionModuleContext
    {
        public IServiceCollection ServiceCollection { get; internal set; }

        public RegistrationDelegate RegistrationDelegate { get; internal set; }
    }
}
