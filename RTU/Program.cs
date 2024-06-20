using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.ConsoleTools;
using System.Data;
using System.ServiceModel;
using RTU.ServiceReference;


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
