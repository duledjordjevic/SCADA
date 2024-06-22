using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.ConsoleTools;
using Trending.TrendingReference;
namespace Trending
{
    public class Menu
    {
        private readonly string title = @"
            ████████╗██████╗ ███████╗███╗   ██╗██████╗ ██╗███╗   ██╗ ██████╗ 
            ╚══██╔══╝██╔══██╗██╔════╝████╗  ██║██╔══██╗██║████╗  ██║██╔════╝ 
               ██║   ██████╔╝█████╗  ██╔██╗ ██║██║  ██║██║██╔██╗ ██║██║  ███╗
               ██║   ██╔══██╗██╔══╝  ██║╚██╗██║██║  ██║██║██║╚██╗██║██║   ██║
               ██║   ██║  ██║███████╗██║ ╚████║██████╔╝██║██║ ╚████║╚██████╔╝
               ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝╚═════╝ ╚═╝╚═╝  ╚═══╝ ╚═════╝ 
        ";

        public void StartMenu()
        {
            PrettyConsole.WriteLine(title);
            Program.trendingServiceClient.Subscribe();
            while (true) { }
        }
    }
}
