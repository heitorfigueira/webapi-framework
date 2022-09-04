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
    public class SingletonService : ServiceBase, IInjectableService
    {

        public SingletonService() : base() { }
        public SingletonService(IConfiguration configuration, IMapper mapper) : base(configuration, mapper) { }
        public SingletonService(IConfiguration configuration) : base(configuration) { }
        public SingletonService(IMapper mapper) : base(mapper) { }

        public IServiceCollection InjectService(IServiceCollection collection, IConfiguration config, Type implementation, Type service)
        {
            collection.AddSingleton(service, implementation);

            return collection;
        }
    }
}
