using BrainStorms.Examples.ServiceInterfaceHierarchy.Core;
using BrainStorms.Examples.ServiceInterfaceHierarchy.Extensions;
using BrainStorms.Examples.ServiceInterfaceHierarchy.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorms.Examples.ServiceInterfaceHierarchy
{
    public class ServiceHierarchy
    {
        static void Main()
        {
            using IHost host = CreateHostBuilder(null).Build();
            var serviceProvider = host.Services;

            var consoleHost = serviceProvider.GetService<IEntryPoint>();
            consoleHost.Execute();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<IEntryPoint, EntryPoint>()
                        .AddSingleton<IMessage, OverrideMessage>().AddExampleHostBuilder());
    }
}
