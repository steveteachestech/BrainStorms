using System.Collections.Generic;

namespace BrainStorms.Examples.DependancyInjection.ImprovedNoDI.SendTypes
{
    internal class SendTwitter : ISend
    {
        public string Name => "Twitter";
        public string Message => "Hi Twitter!";

        public Dictionary<string, string> Settings { get; set; }

        public bool SendMessage()
        {
            return true;
        }
    }
}