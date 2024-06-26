﻿using CommonLibrary.ConsoleTools;
using CommonLibrary.Model;
using DatabaseManager.TagServiceReference;
using DatabaseManager.UserServiceReference;
using System;
using System.Threading;

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
                |4) Get all outputs    |
                |5) Toggle scan        |
                |6) Add tag            |
                |7) Remove tag         |
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
                        tagClientAdapter.SetOutput();
                        break;

                    case "3":
                        tagClientAdapter.GetOutput();
                        break;

                    case "4":
                        tagClientAdapter.GetAllOutputs();
                        Console.ReadKey();
                        break;

                    case "5":
                        tagClientAdapter.ToggleScan();
                        break;

                    case "6":
                        var tag = TagMenu();
                        if (tag == null) { continue; }

                        tagClientAdapter.AddTag(tag);
                        break;

                    case "7":
                        tagClientAdapter.RemoveTag();
                        break;

                    case "x":
                        userClientAdapter.Logout(token);
                        token = "";
                        break;

                    default:
                        PrettyConsole.WriteLine("Error: Invalid choice.");
                        break;
                }
                Thread.Sleep(1000);

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
