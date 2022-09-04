using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Framework.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static (IServiceCollection collection, IConfiguration configuration) GetServicesAndConfiguration(this WebApplicationBuilder builder)
        {
            return (builder.Services, builder.Configuration);
        }
    }
}
