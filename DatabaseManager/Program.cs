using DatabaseManager.UserServiceReference;
using DatabaseManager.TagServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class Program
    {
        public class TagCallback :  ITagServiceCallback
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
