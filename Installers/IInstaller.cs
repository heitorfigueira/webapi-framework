using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Framework.Installers
{
    public interface IInstaller
    {
        public int Order => -1;

        void AddServices(IServiceCollection services, IConfiguration configuration);

    }
}
