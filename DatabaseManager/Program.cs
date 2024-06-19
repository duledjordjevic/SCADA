﻿using DatabaseManager.UserServiceReference;
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
        public class Callback : IUserServiceCallback, ITagServiceCallback
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
            InstanceContext uic = new InstanceContext(new Callback());
            userClient = new UserServiceClient(uic);

            InstanceContext tic = new InstanceContext(new Callback());
            tagClient = new TagServiceClient(tic);

            var menu = new Menu(userClient, tagClient);
            menu.StartMenu();

            //userClient.Register("rade", "sifra");
            //userClient.Login("rade", "laznjak");
            //var token = userClient.Login("rade", "sifra");
            //Console.WriteLine(token);
            //userClient.Logout(token);
            Console.ReadKey();
        }
    }
}
