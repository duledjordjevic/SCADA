using CommonLibrary.ConsoleTools;
using Core.Service;
using ReportManager.ReportServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportManager
{
    public class Menu
    {
        private readonly ReportClientAdapter reportClientAdapter;
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

        public Menu (ReportServiceClient reportClient)
        {
            reportClientAdapter = new ReportClientAdapter(reportClient);
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
                        var alarmDates = ReportConsoleReader.GetAlarmsByPeriod();
                        reportClientAdapter.GetAlarmsByPeriod(alarmDates.startTime, alarmDates.endTime);
                        break;

                    case "2":
                        var id = ReportConsoleReader.GetAlarmsByPriority();
                        reportClientAdapter.GetAlarmsByPriority(id);
                        break;

                    case "3":
                        var tagDates = ReportConsoleReader.GetTagValuesByPeriod();
                        reportClientAdapter.GetTagValuesByPeriod(tagDates.startTime, tagDates.endTime);
                        break;

                    case "4":
                        reportClientAdapter.GetLastAITagValues();
                        break;

                    case "5":
                        reportClientAdapter.GetLastDITagValues();
                        break;

                    case "6":
                        var tag = ReportConsoleReader.GetTagValuesById();
                        reportClientAdapter.GetTagValuesById(tag);
                        break;

                    case "x":
                        PrettyConsole.WriteLine("Exited.");
                        return;

                    default:
                        PrettyConsole.WriteLine("Error: Invalid choice.");
                        Thread.Sleep(1000);
                        break;
                }
                
            }
        }
    }
}
