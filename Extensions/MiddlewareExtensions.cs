using Microsoft.AspNetCore.Builder;
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
    public static class MiddlewareInstallerExtensions
    {
        public static void AddMidlewareInstallersFromCurrentAssembly(this WebApplication app)
        {
            AddMiddlewareInstallersFromAssemblies(app, Assembly.GetExecutingAssembly());
        }

        public static void AddMiddlewareInstallersFromAssemblyContaining<TMarker>(this WebApplication app)
        {
            AddMiddlewareInstallersFromAssembliesContaining(app, typeof(TMarker));
        }

        public static void AddMiddlewareInstallersFromAssembliesContaining(this WebApplication app, params Type[] assemblyMarkers)
        {
            var assemblies = assemblyMarkers.Select(x => x.Assembly).ToArray();
            AddMiddlewareInstallersFromAssemblies(app, assemblies);
        }

        public static void AddMiddlewareInstallersFromAssemblies(this WebApplication app, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var installerTypes = assembly.DefinedTypes
                    .Where(x => typeof(IMiddlewareInstaller).IsAssignableFrom(x) 
                                && !x.IsInterface 
                                && !x.IsAbstract)
                    .Select(Activator.CreateInstance)
                    .Cast<IMiddlewareInstaller>();

                foreach (var installer in installerTypes)
                {
                    installer.AddMiddlewareInstaller(app);
                }
            }
        }
    }
}
