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
using CommonLibrary.Console;

namespace DatabaseManager
{

    public class Menu
    {
        private readonly UserClientAdapter userClientAdapter;
        private readonly TagClientAdapter tagClientAdapter;

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
                +-------- TAGS --------+
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
            token = "";
            while (token.Equals("")) 
            {
                PrettyConsole.WriteTitle(startMenu);
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
                        break;
                }
            }
            MainMenu();
        }

        public void MainMenu()
        {
            while (!token.Equals(""))
            {
                PrettyConsole.WriteTitle(mainMenu);
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
                        PrettyConsole.WriteLine($"{tag}");
                        if (tag == null) { continue; }

                        tagClientAdapter.AddTag(tag);
                        //Thread.Sleep(5000);
                        break;

                    case "6":
                        tagClientAdapter.RemoveTag("Vrata");
                        Thread.Sleep(5000);
                        break;

                    case "x":
                        userClientAdapter.Logout(token);
                        token = "";
                        break;

                    default:
                        PrettyConsole.WriteLine("Error: Invalid choice.");
                        Thread.Sleep(1000);
                        break;
                }

            }
            StartMenu();
        }

        public Tag TagMenu()
        {
            Tag tag = null;
            while (tag == null)
            {
                PrettyConsole.WriteTitle(tagMenu);
                PrettyConsole.Write("Enter choice: ");
                var input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                        tag = TagConsoleReader.ReadDI();
                        break;

                    case "2":
                        tag = TagConsoleReader.ReadDO();
                        break;

                    case "3":
                        tag = TagConsoleReader.ReadAI();
                        break;

                    case "4":
                        tag = TagConsoleReader.ReadAO();
                        break;

                    case "x":
                        return null;

                    default:
                        PrettyConsole.WriteLine("Error: Invalid choice.");
                        Thread.Sleep(1000);
                        break;
                }
            }
            return tag;
        }




    }
}
