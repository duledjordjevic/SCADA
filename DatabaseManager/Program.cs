using CommonLibrary.ConsoleTools;
using DatabaseManager.TagServiceReference;
using DatabaseManager.UserServiceReference;
using System;
using System.ServiceModel;

namespace DatabaseManager
{
    public class Program
    {
        public class TagCallback : ITagServiceCallback
        {
            public void MessageArrived(string message)
            {
                PrettyConsole.WriteLine(message);
            }
        }

        public class UserCallback : IUserServiceCallback
        {
            public void MessageArrived(string message)
            {
                PrettyConsole.WriteLine(message);
            }
        }

        static UserServiceClient userClient;

        static TagServiceClient tagClient;

        static void Main(string[] args)
        {
            InstanceContext uic = new InstanceContext(new UserCallback());
            userClient = new UserServiceClient(uic);

            InstanceContext tic = new InstanceContext(new TagCallback());
            tagClient = new TagServiceClient(tic);

            var menu = new Menu(userClient, tagClient);
            menu.StartMenu();

            Console.ReadKey();
        }
    }
}
