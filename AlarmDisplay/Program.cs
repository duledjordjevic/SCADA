using AlarmDisplay.AlarmServiceReference;
using CommonLibrary.ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AlarmDisplay
{
    public class Program
    {
        public class AlarmCallback : IAlarmServiceCallback
        {
            public void MessageArrived(string message)
            {
                PrettyConsole.WriteLine(message);
            }
        }

        static AlarmServiceClient alarmClient;

        static void Main(string[] args)
        {
            InstanceContext uic = new InstanceContext(new AlarmCallback());
            alarmClient = new AlarmServiceClient(uic);

            alarmClient.Subscribe();

            var menu = new Menu();
            menu.StartMenu();
        }
    }
}
