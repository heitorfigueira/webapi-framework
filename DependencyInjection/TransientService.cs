using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Framework.DependencyInjection
{
    public class TransientService : IInjectableService
    {
        public IServiceCollection InjectService(IServiceCollection collection, IConfiguration config, Type implementation, Type service)
        {
            collection.AddTransient(service, implementation);

            return collection;
        }
    }
}
