using Brainstorms.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BrainStorms.Examples.PluginArchitecture
{
    class PluginExample
    {
        static void Main()
        {
            using IHost host = CreateHostBuilder(null).Build();
            var serviceProvider = host.Services;

            var consoleHost = serviceProvider.GetService<IPluginManager>();
            consoleHost.Execute();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<IPluginManager, PluginManager>()
                            .AddTransientFromAssembliesInPath<IPlugin>(@"C:\Users\steve.MUPPET\source\repos\BrainStorms\Brainstorms.Plugins\bin\Debug\net5.0"));
    }

    internal class PluginManager : IPluginManager
    {
        private readonly IServiceProvider _provider;

        public PluginManager(IServiceProvider provider)
        {
            _provider = provider;
        }
        public void Execute()
        {
            _provider.GetService<IPlugin>().Run();


        }
    }

    internal interface IPluginManager
    {
        void Execute();
    }


}
