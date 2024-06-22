using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.ConsoleTools
{
    public class ConsoleReader
    {
        private static string InfoString(string info)
        {
            return $"Enter {info}: ";
        }

        private static string ErrorString(string error)
        {
            return $"Error: {error}.";
        }

        public static string ReadString(string info, string error)
        {
            string input;
            do
            {
                PrettyConsole.Write(InfoString(info));
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    PrettyConsole.WriteLine(ErrorString(error));
                }

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public static bool ReadBool(string info)
        {
            while (true)
            {
                PrettyConsole.Write($"{info} (y/n): ");
                var input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    PrettyConsole.WriteLine(ErrorString("Invalid input"));
                }
            }
        }

        public static int ReadZeroOrOne(string info, string error)
        {
            while (true)
            {
                PrettyConsole.Write(InfoString(info));
                string input = Console.ReadLine();

                if (input == "0" || input == "1")
                {
                    return int.Parse(input);
                }
                else
                {
                    PrettyConsole.WriteLine(ErrorString(error));
                }
            }
        }

        public static int ReadPositiveInteger(string info, string error)
        {
            while (true)
            {
                PrettyConsole.Write(InfoString(info));
                string input = Console.ReadLine();
                int number;

                if (int.TryParse(input, out number) && number > 0)
                {
                    return number;
                }
                else
                {
                    PrettyConsole.WriteLine(ErrorString(error));
                }
            }
        }

        public static double ReadDouble(string info, string error)
        {
            while (true)
            {
                PrettyConsole.Write(InfoString(info));
                string input = Console.ReadLine();
                double number;

                // Try to parse the input as a double
                if (double.TryParse(input, out number))
                {
                    return number;
                }
                else
                {
                    PrettyConsole.WriteLine(ErrorString(error));
                }
            }
        }

        public static string ReadMenuSelection(string menu, List<string> returnValues)
        {
            int choice = -1;
            while (true)
            {
                Console.WriteLine(menu);
                PrettyConsole.Write("Enter choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) && choice >= 1 && choice <= returnValues.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Invalid input.");
                }
            }
            return returnValues[choice - 1];
        }

        public static double ReadDoubleGreaterThan(double comparison, string info, string error)
        {
            while (true)
            {
                PrettyConsole.Write(InfoString(info));
                string input = Console.ReadLine();

                if (double.TryParse(input, out double userInput))
                {
                    if (userInput > comparison)
                    {
                        return userInput;
                    }
                    else
                    {
                        PrettyConsole.WriteLine(ErrorString(error));
                    }
                }
                else
                {
                    PrettyConsole.WriteLine(ErrorString(error));
                }
            }
        }
    }
}
