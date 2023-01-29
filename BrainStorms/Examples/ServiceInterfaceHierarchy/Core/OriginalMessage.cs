using System;
using BrainStorms.Examples.ServiceInterfaceHierarchy.Interfaces;

namespace BrainStorms.Examples.ServiceInterfaceHierarchy.Core
{
    public class OriginalMessage : IMessage
    {
        public void Message()
        {
            Console.WriteLine("Hello");
        }
    }
}
