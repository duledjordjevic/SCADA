using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.ConsoleTools;

namespace DatabaseManager
{
    public class UserConsoleReader
    {
        public static string ReadPassword()
        {
            string password;

            do
            {
                PrettyConsole.Write("Enter password: ");
                password = string.Empty;
                ConsoleKeyInfo key;

                do
                {
                    key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                    else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                } while (key.Key != ConsoleKey.Enter);

                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(password))
                {
                    PrettyConsole.WriteLine("Error: Password cannot be empty.");
                }

            } while (string.IsNullOrWhiteSpace(password));

            return password;
        }

        public static string ReadUsername()
        {
            string username;
            do
            {
                PrettyConsole.Write("Enter username: ");
                username = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username))
                {
                    PrettyConsole.WriteLine("Error: Username cannot be empty.");
                }

            } while (string.IsNullOrWhiteSpace(username));

            return username;
        }
    }
}
