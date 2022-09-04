using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Framework.DependencyInjection
{
    public class ScopedService : ServiceBase, IInjectableService
    {

        public ScopedService() : base() { }
        public ScopedService(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }
        public ScopedService(IConfiguration configuration) : base (configuration) { }
        public ScopedService(IMapper mapper) : base(mapper) { }

        public IServiceCollection InjectService(IServiceCollection collection, IConfiguration config, Type implementation, Type service)
        {
            collection.AddScoped(service, implementation);

            return collection;
        }
    }
}
