using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Installers;

namespace WebApi.Framework.Extensions
{
    public static class InstallerExtensions
    {
        public static void AddInstallersFromCurrentAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            AddInstallersFromAssemblies(services, configuration, Assembly.GetExecutingAssembly());
        }

        public static void AddInstallersFromAssemblyContaining<TMarker>(this IServiceCollection services, IConfiguration configuration)
        {
            AddInstallersFromAssembliesContaining(services, configuration, typeof(TMarker));
        }

        public static void AddInstallersFromAssembliesContaining(this IServiceCollection services, IConfiguration configuration, params Type[] assemblyMarkers)
        {
            var assemblies = assemblyMarkers.Select(x => x.Assembly).ToArray();
            AddInstallersFromAssemblies(services, configuration, assemblies);
        }

        public static void AddInstallersFromAssemblies(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var installerTypes = assembly.DefinedTypes
                    .Where(x => typeof(IInstaller).IsAssignableFrom(x) 
                                && !x.IsInterface 
                                && !x.IsAbstract)
                    .Select(Activator.CreateInstance)
                    .Cast<IInstaller>();

                foreach (var installer in installerTypes)
                {
                    installer.AddServices(services, configuration);
                }
            }
        }
    }
}
