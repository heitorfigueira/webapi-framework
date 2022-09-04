using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Framework.DependencyInjection
{
    public interface IInjectableService
    {
        IServiceCollection InjectService(IServiceCollection collection, IConfiguration config, Type implementation, Type service);
    }
}
