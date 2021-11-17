using BrainStorms.Examples.DependancyInjection.Improved.Resolver;
using BrainStorms.Examples.DependancyInjection.Improved.SendTypes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorms.Examples.DependancyInjection.Improved
{
    public class ImprovedMultipleDI
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
                    services.AddTransient<SendEMail>()
                            .AddTransient<SendTwitter>()
                            .AddTransient<SendNull>()
                            .AddTransient<ISendManager,SendManager>()
                            .AddTransient<ISendResolver, SendResolver>());
    }
}
