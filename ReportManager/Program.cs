using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.ConsoleTools;
using ReportManager.ReportServiceReference;

namespace ReportManager
{
    internal class Program
    {
        public class ReportCallback : IReportServiceCallback
        {
            public void MessageArrived(string message)
            {
                PrettyConsole.WriteLine(message);
            }
        }

        static ReportServiceClient reportClient;

        static void Main(string[] args)
        {
            InstanceContext ric = new InstanceContext(new ReportCallback());
            reportClient = new ReportServiceClient(ric);

            var menu = new Menu(reportClient);
            menu.StartMenu();

            Console.ReadKey();
        }
    }
}
