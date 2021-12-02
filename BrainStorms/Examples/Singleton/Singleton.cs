using BrainStorms.Examples.Singleton.SendTypes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorms.Examples.Singleton
{
    public class Singleton
    {
        static void Main()
        {
            using IHost host = CreateHostBuilder(null).Build();
            var serviceProvider = host.Services;

            var consoleHost = serviceProvider.GetService<ISendManager>();
            consoleHost.Execute();
            var singletonInjection = serviceProvider.GetService<SingletonInjectionSample>();
            singletonInjection.Run();

        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
               services.AddTransient<ISend, SendMail>()
                       .AddTransient<ISend, SendTwitter>()
                       .AddTransient<ISend, SendNull>()
                       .AddTransient<SingletonInjectionSample>()
                       .AddSingleton<ISendManager>(c => {
                           return SendManager.GetInstance(c.GetServices<ISend>());
                           }));
    }
}
