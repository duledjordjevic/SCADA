using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonLibrary.ConsoleTools
{
    public class PrettyConsole
    {
        private static readonly string title = @"
                
         ███████╗ ██████╗ █████╗ ██████╗  █████╗ 
         ██╔════╝██╔════╝██╔══██╗██╔══██╗██╔══██╗
         ███████╗██║     ███████║██║  ██║███████║
         ╚════██║██║     ██╔══██║██║  ██║██╔══██║
         ███████║╚██████╗██║  ██║██████╔╝██║  ██║
         ╚══════╝ ╚═════╝╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝                 
            ";

        public static void Write(string text)
        {
            Console.Write($"         {text}");
        }

        public static void WriteLine(string text)
        {
            ChangeColorBasedOnContent(text);
            Console.WriteLine($"         {text}");
            Console.ResetColor();
        }

        public static void WriteTitle(string text)
        {
            Console.Clear();
            Console.WriteLine(title + text);
        }

        private static void ChangeColorBasedOnContent(string text)
        {
            Regex errorRegex = new Regex(@"(?i)(error|fail)");
            Regex successRegex = new Regex(@"(?i)success");

            if (errorRegex.IsMatch(text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (successRegex.IsMatch(text))
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ResetColor();
            }
        }
    }
}
