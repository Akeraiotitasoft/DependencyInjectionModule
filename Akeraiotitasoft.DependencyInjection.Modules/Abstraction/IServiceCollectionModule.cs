using Microsoft.Extensions.DependencyInjection;
using System;

namespace Akeraiotitasoft.DependencyInjection.Modules.Abstraction
{
    public interface IServiceCollectionModule
    {
        void ConfigureServices(IServiceCollection serviceCollection);
    }
}
