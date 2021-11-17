using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using BrainStorms;

namespace BrainStorms.Examples.DependancyInjection.Simple
{
    internal class SendManager : ISendManager
    {
        private readonly ISend _sendMessage;

        public SendManager(IEnumerable<ISend> sendMessages)
        {
            _sendMessage = sendMessages.SingleOrDefault(s => s.Name.ToLower() == Program.Configuration["SendType"].ToLower());
        }
        public void Execute()
        {
            Console.WriteLine(_sendMessage?.Message);
        }
    }
}