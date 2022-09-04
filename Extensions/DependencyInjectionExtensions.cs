using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.DependencyInjection;

namespace WebApi.Framework.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddServicesFromAssemblies(services, configuration, Assembly.GetExecutingAssembly());
        }

        public static void AddServicesFromAssemblyContaining<TMarker>(this IServiceCollection services, IConfiguration configuration)
        {
            AddServicesFromAssembliesContaining(services, configuration, typeof(TMarker));
        }

        public static void AddServicesFromAssembliesContaining(this IServiceCollection services, IConfiguration configuration, params Type[] assemblyMarkers)
        {
            var assemblies = assemblyMarkers.Select(x => x.Assembly).ToArray();
            AddServicesFromAssemblies(services, configuration, assemblies);
        }

        public static void AddServicesFromAssemblies(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
        {

            List<TypeInfo?> definedTypes = new();

            Array.ForEach(assemblies, (assembly) => definedTypes.AddRange(assembly.DefinedTypes));

            var implementationTypes = definedTypes
                .Where(x => typeof(IInjectableService).IsAssignableFrom(x)
                            && !x.IsInterface
                            && !x.IsAbstract);

            var castedTypes = implementationTypes.Select(FormatterServices.GetUninitializedObject!).Cast<IInjectableService>();

            foreach (var (implementation, i) in implementationTypes.Select((implementation, i) => (implementation, i)))
            {
                var serviceContract = castedTypes.ElementAt(i);

                var serviceType = implementation!.ImplementedInterfaces.FirstOrDefault(impInterf => impInterf != typeof(IInjectableService))!;

                serviceContract.InjectService(services, configuration, implementation, serviceType);
            }
        }
    }
}
