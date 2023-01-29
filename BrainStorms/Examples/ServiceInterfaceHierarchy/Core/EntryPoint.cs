using BrainStorms.Examples.ServiceInterfaceHierarchy.Interfaces;

namespace BrainStorms.Examples.ServiceInterfaceHierarchy.Core
{
    public class EntryPoint : IEntryPoint
    {
        private readonly IMessage w;

        public EntryPoint(IMessage w)
        {
            this.w = w;
        }
        public void Execute()
        {
            w.Message();
        }
    }
}
