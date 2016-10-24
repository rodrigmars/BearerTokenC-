using Topshelf;

namespace SelfhostService
{
    class Program
    {
        static void Main(string[] args)
        {

            HostFactory.Run(factory => {

                factory.Service<ServiceHost>(fc =>
                {
                    fc.ConstructUsing(() => new ServiceHost());
                    fc.WhenStarted(sh => sh.Start());
                    fc.WhenShutdown(sh => sh.Shutdown());
                    fc.WhenStopped(sh => sh.Stop());
                });

                factory.RunAsLocalSystem();
                factory.SetDescription("Demo using TopShelf");
                factory.SetDisplayName("TopShelf Demo");
                factory.SetServiceName("TopShelfDemo");
            });

        }
    }
}
