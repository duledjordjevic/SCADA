using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class ConsoleReader
    {
        public static string ReadString(string info, string error)
        {
            string input;
            do
            {
                PrettyConsole.Write($"{info}");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    PrettyConsole.WriteLine($"Error: {error}");
                }

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public bool ReadBool(string info, string error)
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
                    PrettyConsole.WriteLine("Error: Invalid input.");
                }
            }
        }

        public int ReadPositiveInteger(string info, string error)
        {
            while (true)
            {
                PrettyConsole.Write($"{info}");
                string input = Console.ReadLine();
                int number;

                if (int.TryParse(input, out number) && number > 0)
                {
                    return number;
                }
                else
                {
                    PrettyConsole.WriteLine($"Error: {error}");
                }
            }
        }

        public double ReadDouble(string info, string error)
        {
            while (true)
            {
                PrettyConsole.Write($"{info}");
                string input = Console.ReadLine();
                double number;

                // Try to parse the input as a double
                if (double.TryParse(input, out number))
                {
                    return number;
                }
                else
                {
                    PrettyConsole.WriteLine($"Error: {error}");
                }
            }
        }

    }
}
