using CommonLibrary.ConsoleTools;
using System.ServiceModel;
using Trending.TrendingReference;

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
