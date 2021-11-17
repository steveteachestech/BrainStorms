using BrainStorms.Examples.DependancyInjection.ImprovedNoDI.SendTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorms.Examples.DependancyInjection.ImprovedNoDI.Resolver
{
    class SendResolver : ISendResolver
    {
        public ISend Register()
        {
            Type t = typeof(SendNull);
            var type = Assembly.GetAssembly(t).GetType($"{t.Namespace}.Send{Program.Configuration["SendType"]}");
            var instance = Activator.CreateInstance(type);
            return instance as ISend;
        }
    }
}
