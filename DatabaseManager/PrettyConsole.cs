using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class PrettyConsole
    {
        public static void Write(string text)
        {
            Console.Write($"         {text}");
        }

        public static void WriteLine(string text)
        {
            Console.WriteLine($"         {text}");
        }
    }
}
