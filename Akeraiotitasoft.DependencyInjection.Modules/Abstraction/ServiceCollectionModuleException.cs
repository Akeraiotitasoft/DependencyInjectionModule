using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.DependencyInjection.Modules
{
    public class ServiceCollectionModuleException : Exception
    {
        public ServiceCollectionModuleException() : base("Error in ServiceCollectionModule")
        {
        }

        public ServiceCollectionModuleException(string message) : base(message)
        {
        }

        public ServiceCollectionModuleException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
