using System;
using System.Collections.Generic;

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

        public static int ReadFromList(string info, string error, List<int> validNumbers)
        {
            while (true)
            {
                PrettyConsole.Write(InfoString(info));
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number) && validNumbers.Contains(number))
                {
                    return number;
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

        public static DateTime ReadDateTime(string info, string error)
        {
            while (true)
            {
                int month = ReadPositiveInteger($"{info} month:", error);
                int day = ReadPositiveInteger($"{info} day:", error);
                int hour = ReadPositiveInteger($"{info} hour:", error);

                try
                {
                    DateTime date = new DateTime(2024, month, day, hour, 0, 0);
                    return date;
                }
                catch (ArgumentOutOfRangeException)
                {
                    PrettyConsole.WriteLine(ErrorString(error));
                }
            }
        }

        public static void ReadStartAndEndDateTimes(out DateTime startDate, out DateTime endDate)
        {
            while (true)
            {
                startDate = ReadDateTime("start", "Must be valid date");

                if (startDate >= DateTime.Now)
                {
                    PrettyConsole.WriteLine(ErrorString("Must be before now"));
                    continue;
                }

                endDate = ReadDateTime("end", "Must be valid date");

                if (endDate >= DateTime.Now)
                {
                    PrettyConsole.WriteLine(ErrorString("Can`t be after now"));
                    continue;
                }

                if (endDate <= startDate)
                {
                    PrettyConsole.WriteLine(ErrorString("Must be after start date"));
                    continue;
                }

                break;
            }
        }
    }
}
