using Akeraiotitasoft.DependencyInjection.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Test.Mock
{
    public class Module : IServiceCollectionModule
    {
        public void ConfigureServices(IServiceCollectionModuleContext context)
        {
            context.AddSingleton<IA, MockA>();
            context.AddSingleton<IB, MockB>();
        }
    }
}
