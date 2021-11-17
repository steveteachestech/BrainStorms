﻿using System.Collections.Generic;


namespace BrainStorms.Examples.DependancyInjection.ImprovedNoDI.SendTypes
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