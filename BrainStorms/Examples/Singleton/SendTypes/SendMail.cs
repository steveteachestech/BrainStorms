using System.Collections.Generic;
using BrainStorms.Examples.Singleton;

namespace BrainStorms.Examples.Singleton.SendTypes
{
    internal class SendMail : ISend
    {
        public string Name => "EMail";
        public string Message => "Hi Email";

        public Dictionary<string, string> Settings { get; set; }

        public bool SendMessage()
        {
            return true;
        }
    }
}