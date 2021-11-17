using System.Collections.Generic;
using BrainStorms.Examples.DependancyInjection;


namespace BrainStorms.Examples.DependancyInjection.Simple
{
    internal class SendNull : ISend
    { 
        public string Name => "Null";
        public string Message => "Hi Null";


        public Dictionary<string, string> Settings { get; set; }

        public bool SendMessage()
        {
            return true;
        }
    }
}