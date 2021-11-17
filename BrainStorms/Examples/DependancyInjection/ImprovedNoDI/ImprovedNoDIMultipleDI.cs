using BrainStorms.Examples.DependancyInjection.ImprovedNoDI.Resolver;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorms.Examples.DependancyInjection.ImprovedNoDI
{
    public class ImprovedNoDIMultipleDI
    {
        static void Main()
        {
            using IHost host = CreateHostBuilder(null).Build();
            var serviceProvider = host.Services;

            var consoleHost = serviceProvider.GetService<ISendManager>();
            consoleHost.Execute();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<ISendResolver, SendResolver>()
                            .AddTransient<ISendManager,SendManager>());
    }
}
