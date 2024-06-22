using CommonLibrary.ConsoleTools;


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
