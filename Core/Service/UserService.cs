using Core.Repository;
using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Core.Model;

namespace Core.Service
{
    public class UserService : BaseService, IUserService
    {
        static MessageArrivedDelegate notifier;

        public void Login(string username, string password)
        {

            SendMessage(notifier, $"{username} - {password}");
        }

        public void Register(string username, string password)
        {
            InitNotifier();   

            using(var db = new DatabaseContext())
            {
                db.Users.Add(new User(username, password));
                db.SaveChanges();
            }

            SendMessage(notifier, $"Registration successful: {username} - {password}");
        }

        protected override void InitNotifier()
        {
            notifier = OperationContext.Current.GetCallbackChannel<ICallBack>().MessageArrived;
        }
    }
}
