using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Trending.TrendingReference;
using CommonLibrary.ConsoleTools;

namespace Trending
{
    internal class Program
    {
        public class TrendingCallback : ITrendingServiceCallback
        {
            public void MessageArrived(string message)
            {
                PrettyConsole.WriteLine(message);
            }
        }

        public static TrendingServiceClient trendingServiceClient;
        static void Main(string[] args)
        {
            InstanceContext uic = new InstanceContext(new TrendingCallback());
            trendingServiceClient = new TrendingServiceClient(uic);

            var menu = new Menu();
            menu.StartMenu();
        }
    }
}
