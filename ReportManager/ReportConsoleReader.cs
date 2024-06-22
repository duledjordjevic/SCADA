using CommonLibrary.ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    public class ReportConsoleReader
    {

        private static readonly Dictionary<string, string> infos = new Dictionary<string, string>
        {
            { "startTime", "start" },
            { "endTime", "end" },
            { "tagName", "tag name" },
            { "priority", "alarm priority" }
        };

        private static readonly Dictionary<string, string> errors = new Dictionary<string, string>
        {
            { "startTime", "Must be valid date" },
            { "endTime", "Must be after start date" },
            { "tagName", "Must be filled" },
            { "priority", "Must be number" }
        };

        public static (DateTime startTime, DateTime endTime) GetTagValuesByPeriod()
        {
            var startTime = ConsoleReader.ReadDateTime(infos["startTime"], errors["startTime"]);
            var endTime = ConsoleReader.ReadDateTime(infos["endTime"], errors["endTime"]);

            return (startTime, endTime);
        }

        public static string GetTagValuesByName()
        {
            var tagName = ConsoleReader.ReadString(infos["tagName"], errors["tagName"]);
            return tagName;
        }

        public static (DateTime startTime, DateTime endTime) GetAlarmsByPeriod()
        {
            var startTime = ConsoleReader.ReadDateTime(infos["startTime"], errors["startTime"]);
            var endTime = ConsoleReader.ReadDateTime(infos["endTime"], errors["endTime"]);

            return (startTime, endTime);
        }

        public static int GetAlarmsByPriority()
        {
            int priority = ConsoleReader.ReadPositiveInteger(infos["priority"], errors["priority"]);

            return priority;
        }
    }
}
