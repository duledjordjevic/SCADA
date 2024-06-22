using Core.Repository;
using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Core.Model;
using CommonLibrary;

namespace Core.Service
{
    public class UserService : IBaseService, IUserService
    {
        public static Dictionary<string, User> authenticatedUsers = new Dictionary<string, User>();

        static MessageArrivedDelegate notifier;

        public string Login(string username, string password)
        {
            InitNotifier();
            var token = "";
            using (var db = new DatabaseContext())
            {
                foreach (var user in db.Users)
                {
                    if (username == user.Username &&
                   AuthProvider.Validate(password, user.Password))
                    {
                        token = AuthProvider.GenerateToken(username);
                        authenticatedUsers.Add(token, user);
                        SendMessage($"Login successful!");
                        return token;
                    }
                }
            }
            SendMessage($"Error: Login failed!");
            return token;
        }

        public bool Logout(string token)
        {
            authenticatedUsers.Remove(token);
            SendMessage($"Logged out.");
            return true;
        }

        public bool Register(string username, string password)
        {
            InitNotifier();

            using (var db = new DatabaseContext())
            {
                try
                {
                    db.Users.Add(new User(username, AuthProvider.Encrypt(password)));
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    SendMessage($"Error: Registration failed!");
                    return false;
                }
            }

            SendMessage($"Registration successful: {username}");
            return true;
        }

        public void InitNotifier()
        {
            notifier = OperationContext.Current.GetCallbackChannel<ICallBack>().MessageArrived;
        }

        public void SendMessage(string message)
        {
            notifier?.Invoke(message);
        }
    }
}
