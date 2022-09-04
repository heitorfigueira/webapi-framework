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
    public class TransientService : ServiceBase, IInjectableService
    {

        public TransientService() : base() { }
        public TransientService(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }
        public TransientService(IConfiguration configuration) : base(configuration) { }
        public TransientService(IMapper mapper) : base(mapper) { }

        public IServiceCollection InjectService(IServiceCollection collection, IConfiguration config, Type implementation, Type service)
        {
            collection.AddTransient(service, implementation);

            return collection;
        }
    }
}
