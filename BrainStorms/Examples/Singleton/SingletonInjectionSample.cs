using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorms.Examples.Singleton
{
    public class SingletonInjectionSample
    {
        private readonly ISendManager sendManager;

        public SingletonInjectionSample(ISendManager sendManager)
        {
            this.sendManager = sendManager;
        }

        public void Run()
        {
            sendManager.Execute();
        }
    }
}
