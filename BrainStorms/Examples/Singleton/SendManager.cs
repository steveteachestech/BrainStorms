using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrainStorms.Examples.Singleton
{
    internal class SendManager : ISendManager
    {
        int count = 0;
        private readonly ISend _sendMessage;

        private static ISendManager _instance;

        private SendManager(IEnumerable<ISend> sendMessages) 
        {
            _sendMessage = sendMessages.SingleOrDefault(s => s.Name.ToLower() == Program.Configuration["SendType"].ToLower());
        }

        public static ISendManager GetInstance(IEnumerable<ISend> sendMessages)
        {
            if(_instance == null)
            {
                _instance = new SendManager(sendMessages);
            }

            return _instance;
        }

        public void Execute()
        {
            count++;
            Console.WriteLine($"{count}.{_sendMessage?.Message}");
        }
    }
}