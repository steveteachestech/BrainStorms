using BrainStorms.Examples.ServiceInterfaceHierarchy.Core;
using BrainStorms.Examples.ServiceInterfaceHierarchy.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BrainStorms.Examples.ServiceInterfaceHierarchy.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IExampleHostBuilder AddExampleHostBuilder(this IServiceCollection services)
        {

            //
            // Add required services

            services.TryAddSingleton<IMessage, OriginalMessage>();

            return new ExampleHostBuilder(services);
        }
    }
}
