using CommonLibrary.ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AlarmDisplay
{
    public class Menu
    {
        private readonly string title = @"

          █████╗ ██╗      █████╗ ██████╗ ███╗   ███╗
         ██╔══██╗██║     ██╔══██╗██╔══██╗████╗ ████║
         ███████║██║     ███████║██████╔╝██╔████╔██║
         ██╔══██║██║     ██╔══██║██╔══██╗██║╚██╔╝██║
         ██║  ██║███████╗██║  ██║██║  ██║██║ ╚═╝ ██║
         ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝                     
            ";

        public void StartMenu()
        {
            PrettyConsole.WriteLine(title);
            Program.alarmClient.Subscribe();
            while (true) { }
        }

    }
}
