using Brainstorms.Menu;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace BrainStorms
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);
            
            Configuration = builder.Build();

            MenuRunner.Execute(Assembly.GetExecutingAssembly());
        }
    }

}
