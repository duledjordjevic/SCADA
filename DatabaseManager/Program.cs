using DatabaseManager.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class Program
    {
        public class Callback : IUserServiceCallback
        {
            public void MessageArrived(string message)
            {
                Console.WriteLine(message);
            }
        }

        static UserServiceClient userClient;

        static void Main(string[] args)
        {
            InstanceContext ic = new InstanceContext(new Callback());
            userClient = new UserServiceClient(ic);

            userClient.Register("rade", "srade");
            Console.ReadKey();
        }
    }
}
