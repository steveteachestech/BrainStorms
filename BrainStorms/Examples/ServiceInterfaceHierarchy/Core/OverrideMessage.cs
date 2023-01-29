using System;
using BrainStorms.Examples.ServiceInterfaceHierarchy.Interfaces;

namespace BrainStorms.Examples.ServiceInterfaceHierarchy.Core
{
    public class OverrideMessage : IMessage
    {
        public void Message()
        {
            Console.WriteLine("Override");
        }
    }
}
