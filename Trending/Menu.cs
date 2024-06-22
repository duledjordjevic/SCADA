using CommonLibrary.ConsoleTools;
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
