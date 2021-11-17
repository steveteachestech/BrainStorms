using BrainStorms.Examples.DependancyInjection.Improved.SendTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorms.Examples.DependancyInjection.Improved.Resolver
{
    class SendResolver : ISendResolver
    {
        private readonly IServiceProvider _provider;

        public SendResolver(IServiceProvider provider)
        {
            this._provider = provider;
        }

        public ISend Register()
        {
            Type t = typeof(SendNull);
            var type = Assembly.GetAssembly(t).GetType($"{t.Namespace}.Send{Program.Configuration["SendType"]}");
            var instance = this._provider.GetService(type);
            return instance as ISend;
        }
    }
}
