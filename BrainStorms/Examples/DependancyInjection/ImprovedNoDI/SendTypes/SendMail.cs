using System.Collections.Generic;


namespace BrainStorms.Examples.DependancyInjection.ImprovedNoDI.SendTypes
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