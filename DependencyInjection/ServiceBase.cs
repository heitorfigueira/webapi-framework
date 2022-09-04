using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Framework.DependencyInjection
{
    public abstract class ServiceBase
    {
        protected readonly IConfiguration? _configuration;
        protected readonly IMapper? _mapper;

        public ServiceBase() { }

        public ServiceBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ServiceBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ServiceBase(IConfiguration? configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
    }
}
