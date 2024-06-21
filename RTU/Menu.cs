using CommonLibrary.ConsoleTools;
using RTU.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RTU
{
    public class Menu
    {
        private readonly RTDClientAdapter RTDClientAdapter;

        private static readonly string rtu = @"
        
               ██████╗ ████████╗██╗   ██╗
               ██╔══██╗╚══██╔══╝██║   ██║
               ██████╔╝   ██║   ██║   ██║
               ██╔══██╗   ██║   ██║   ██║
               ██║  ██║   ██║   ╚██████╔╝
               ╚═╝  ╚═╝   ╚═╝    ╚═════╝ 
            ";

        private readonly string startMenu = @"
                +-------- MENU --------+
                |1) Register RTU       |
                |X) Exit               |
                +----------------------+
            ";

        private readonly string rtuTitle = @"
                Real Time Unit Readings
            ";

        public Menu(RealTimeDriverServiceClient rtdClient)
        {
            RTDClientAdapter = new RTDClientAdapter(rtdClient);
        }

        public void StartMenu()
        {
            var registered = false;
            while (!registered)
            {
                PrettyConsole.WriteLine(rtu + startMenu);
                PrettyConsole.Write("Enter choice: ");
                var input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                        RTDClientAdapter.Register();
                        RTDClientAdapter.Configure();
                        registered = true;
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
            Console.Clear();
            PrettyConsole.WriteLine(rtu + rtuTitle);
            RTDClientAdapter.SendData();
        }
    }
}
