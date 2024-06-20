using DatabaseManager.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.ConsoleTools;

namespace DatabaseManager
{
    public class UserClientAdapter
    {
        private readonly UserServiceClient UserClient;

        public UserClientAdapter(UserServiceClient userClient)
        {
            UserClient = userClient;
        }

        public string Login()
        {
            string username = UserConsoleReader.ReadUsername();
            string password = UserConsoleReader.ReadPassword();
            PrettyConsole.WriteLine("Logging in...");
            return UserClient.Login(username, password);
        }

        public void Register()
        {
            string username = UserConsoleReader.ReadUsername();
            string password = UserConsoleReader.ReadPassword();
            PrettyConsole.WriteLine("Registering...");
            UserClient.Register(username, password);
        }

        public void Logout(string token)
        {
            PrettyConsole.WriteLine("Logging out...");
            UserClient.Logout(token);
        }
    }
}
