using Core.Model;
using System.IO;

namespace Core.Repository
{
    public class AlarmLogger
    {
        static readonly string LOG_FILE = @"..\..\alarmsLog.txt";
        static readonly object fileLock = new object();

        public static void LogAlarm(ActivatedAlarm alarm)
        {
            lock (fileLock)
            {
                using (StreamWriter writer = File.AppendText(LOG_FILE))
                {
                    writer.WriteLine(alarm.ToString());
                }
            }
        }
    }
}
