using CommonLibrary.ConsoleTools;
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

        //public Menu (ReportClientService reportClient)
        //{
        //    reportClientAdapter = new ReportClientAdapter(reportClient);
        //}   

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
                        // Implement logic for option 1
                        break;

                    case "2":
                        // Implement logic for option 2
                        break;

                    case "3":
                        // Implement logic for option 3
                        break;

                    case "4":
                        // Implement logic for option 4
                        break;

                    case "5":
                        // Implement logic for option 5
                        break;

                    case "6":
                        // Implement logic for option 6
                        break;

                    case "x":
                        PrettyConsole.WriteLine("Exited.");
                        return;

                    default:
                        PrettyConsole.WriteLine("Error: Invalid choice.");
                        Thread.Sleep(1000);
                        break;
                }
                Console.Clear();
            }
        }
    }
}
