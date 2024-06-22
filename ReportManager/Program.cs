using CommonLibrary.ConsoleTools;
using System;
using ReportManager.ReportServiceReference;
using System.ServiceModel;

namespace ReportManager
{
    public class Program
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
