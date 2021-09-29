using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Modules.Abstraction
{
    public interface IServiceCollectionModuleEx2 : IServiceCollectionModuleEx
    {
        void ConfigureServices(IServiceCollection serviceCollection, RegistrationDelegate2 registrationDelegate);
    }
}
