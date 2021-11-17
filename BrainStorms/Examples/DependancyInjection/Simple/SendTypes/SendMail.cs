using System.Collections.Generic;
using BrainStorms.Examples.DependancyInjection;


namespace BrainStorms.Examples.DependancyInjection.Simple
{
    internal class SendEMail : ISend
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