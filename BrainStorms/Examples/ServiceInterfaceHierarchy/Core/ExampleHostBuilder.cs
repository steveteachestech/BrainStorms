using BrainStorms.Examples.ServiceInterfaceHierarchy.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BrainStorms.Examples.ServiceInterfaceHierarchy.Core
{
    public class ExampleHostBuilder : IExampleHostBuilder
    {
        public ExampleHostBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
