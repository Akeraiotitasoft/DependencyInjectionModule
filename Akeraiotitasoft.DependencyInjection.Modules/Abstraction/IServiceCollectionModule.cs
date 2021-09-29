using Microsoft.Extensions.DependencyInjection;
using System;

namespace Akeraiotitasoft.DependencyInjection.Modules
{
    public interface IServiceCollectionModule
    {
        void ConfigureServices(IServiceCollectionModuleContext context);
    }
}
