using CommonLibrary;
using CommonLibrary.ConsoleTools;
using RTU.ServiceReference;
using System;
using System.ServiceModel;


namespace RTU
{
    public class Program
    {
        public class Callback : IRealTimeDriverServiceCallback
        {
            public void MessageArrived(string message)
            {
                PrettyConsole.WriteLine(message);
            }
        }

        static RealTimeDriverServiceClient rtdClient;

        static void Main(string[] args)
        {
            InstanceContext uic = new InstanceContext(new Callback());
            rtdClient = new RealTimeDriverServiceClient(uic);

            var menu = new Menu(rtdClient);
            menu.StartMenu();

            Console.ReadKey();
        }
    }
}
