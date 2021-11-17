using BrainStorms.Examples.DependancyInjection.Improved.Resolver;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrainStorms.Examples.DependancyInjection.Improved
{
    internal class SendManager : ISendManager
    {
        private readonly ISend _sendMessage;

        public SendManager(ISendResolver resolver)
        {
            _sendMessage = resolver.Register();
        }
        public void Execute()
        {
            Console.WriteLine(_sendMessage?.Message);
        }
    }
}