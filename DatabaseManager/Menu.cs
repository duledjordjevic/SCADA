using DatabaseManager.UserServiceReference;
using DatabaseManager.TagServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLibrary.Model;

namespace DatabaseManager
{

    public class Menu
    {
        private readonly UserClientAdapter userClientAdapter;
        private readonly TagClientAdapter tagClientAdapter;

        private readonly string title = @"
                
         ███████╗ ██████╗ █████╗ ██████╗  █████╗ 
         ██╔════╝██╔════╝██╔══██╗██╔══██╗██╔══██╗
         ███████╗██║     ███████║██║  ██║███████║
         ╚════██║██║     ██╔══██║██║  ██║██╔══██║
         ███████║╚██████╗██║  ██║██████╔╝██║  ██║
         ╚══════╝ ╚═════╝╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝                 
            ";

        private readonly string startMenu = @"
                +-------- MENU --------+
                |1) Login              |
                |X) Exit               |
                +----------------------+
            ";

        private readonly string mainMenu = @"
                +-------- MENU --------+
                |1) Register new user  |
                |2) Set output         |
                |3) Get output         |
                |4) Toggle scan        |
                |5) Add tag            |
                |6) Remove tag         |
                |X) Logout             |
                +----------------------+
            ";

        private readonly string tagMenu = @"
                +-------- MENU --------+
                |1) Digital input      |
                |2) Digital output     |
                |3) Analog input       |
                |4) Analog output      |
                |X) Exit               |
                +----------------------+
            ";

        private string token;

        public Menu(UserServiceClient userClient, TagServiceClient tagClient)
        {
            userClientAdapter = new UserClientAdapter(userClient);
            tagClientAdapter = new TagClientAdapter(tagClient);
        }

        public void StartMenu()
        {
            while (true) 
            {
                Console.WriteLine(title + startMenu);
                PrettyConsole.Write("Enter choice: ");
                var input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                        token = userClientAdapter.Login();
                        break;

                    case "x":
                        PrettyConsole.WriteLine("Exited.");
                        return;

                    default:
                        PrettyConsole.WriteLine("Error: Invalid choice.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }

                if (!token.Equals("")) { break; }
            }

            Console.Clear();
            MainMenu();
        }

        public void MainMenu()
        {
            var valid = false;
            while (!valid)
            {
                Console.WriteLine(title + mainMenu);
                PrettyConsole.Write("Enter choice: ");
                var input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                        userClientAdapter.Register();
                        break;

                    case "2":
                        //SetOutput();
                        break;

                    case "3":
                        //GetOutput();
                        break;

                    case "4":
                        //ToggleScan();
                        break;

                    case "5":
                        var tag = TagMenu();

                        if (tag == null) { break; }

                        tagClientAdapter.AddTag();
                        Thread.Sleep(5000);
                        break;

                    case "6":
                        //RemoveTag();
                        break;

                    case "x":
                        userClientAdapter.Logout(token);
                        token = "";
                        break;

                    default:
                        PrettyConsole.WriteLine("Error: Invalid choice.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
                
                Console.Clear();

                if (token.Equals("")) { break; }
            }
            StartMenu();
        }

        public Tag TagMenu()
        {
            while (true)
            {
                Console.WriteLine(tagMenu);
                PrettyConsole.Write("Enter choice: ");
                var input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                        return TagConsoleReader.ReadDI();

                    case "2":
                        return TagConsoleReader.ReadDO();

                    case "3":
                        return TagConsoleReader.ReadAI();

                    case "4":
                        return TagConsoleReader.ReadAO();

                    case "x":
                        PrettyConsole.WriteLine("Exited.");
                        return null;

                    default:
                        PrettyConsole.WriteLine("Error: Invalid choice.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }




    }
}
