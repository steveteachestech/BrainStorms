using System.Collections.Generic;

namespace BrainStorms.Examples.DependancyInjection.Improved
{
    internal interface ISend
    {
        string Name { get; }
        Dictionary<string, string> Settings { get; set; }
        string Message { get; }

        bool SendMessage();
    }
}