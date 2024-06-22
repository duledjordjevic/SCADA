using CommonLibrary.ConsoleTools;
using System;
using System.Threading;
using ReportManager.ReportServiceReference;

namespace ReportManager
{
    public class Menu
    {
        private ReportClientAdapter reportClientAdapter;

        private readonly string title = @"

      ██████╗ ███████╗██████╗  ██████╗ ██████╗ ████████╗
      ██╔══██╗██╔════╝██╔══██╗██╔═══██╗██╔══██╗╚══██╔══╝
      ██████╔╝█████╗  ██████╔╝██║   ██║██████╔╝   ██║   
      ██╔══██╗██╔══╝  ██╔═══╝ ██║   ██║██╔══██╗   ██║   
      ██║  ██║███████╗██║     ╚██████╔╝██║  ██║   ██║   
      ╚═╝  ╚═╝╚══════╝╚═╝      ╚═════╝ ╚═╝  ╚═╝   ╚═╝                                       
            ";

        private readonly string startMenu = @"
                +--------- MENU ---------+
                |1) Alarms (period)      |
                |2) Alarms (priority)    |
                |3) Tag values (period)  |
                |4) Last AI values       |
                |5) Last DI values       |
                |6) Specific tag values  |
                |X) Exit                 |
                +------------------------+
            ";

        public Menu(ReportServiceClient reportClient)
        {
            reportClientAdapter = new ReportClientAdapter(reportClient, title);
        }

        public void StartMenu()
        {
            while (true)
            {
                PrettyConsole.WriteLine(title + startMenu);
                PrettyConsole.Write("Enter choice: ");
                var input = Console.ReadLine()?.Trim().ToLower();
                switch (input)
                {
                    case "1":
                        reportClientAdapter.GetAlarmsByPeriod();
                        break;

                    case "2":
                        reportClientAdapter.GetAlarmsByPriority();
                        break;

                    case "3":
                        reportClientAdapter.GetTagValuesByPeriod();
                        break;

                    case "4":
                        reportClientAdapter.GetLastAITagValues();
                        break;

                    case "5":
                        reportClientAdapter.GetLastDITagValues();
                        break;

                    case "6":
                        reportClientAdapter.GetTagValuesByName();
                        break;

                    case "x":
                        PrettyConsole.WriteLine("Exited.");
                        return;

                    default:
                        PrettyConsole.WriteLine("Error: Invalid choice.");
                        Thread.Sleep(1000);
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
