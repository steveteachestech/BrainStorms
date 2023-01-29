using Microsoft.Extensions.DependencyInjection;

namespace BrainStorms.Examples.ServiceInterfaceHierarchy.Interfaces
{
    public interface IExampleHostBuilder
    {
        IServiceCollection Services { get; }
    }
}
