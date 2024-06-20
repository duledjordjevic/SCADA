using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.WriteLine($"         {text}");
        }

        public static void WriteTitle(string text)
        {
            Console.Clear();
            Console.WriteLine(title + text);
        }
    }
}
