using Brainstorms.Interfaces;
using System;

namespace Brainstorms.Plugins
{
    public class TestPlugin : IPlugin
    {
        public void Run()
        {
            Console.WriteLine("Hello World");
        }
    }
}
