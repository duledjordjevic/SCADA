using CommonLibrary.ConsoleTools;
using CommonLibrary.Model;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    public class ReportConsoleReader
    {
        private readonly ReportClientAdapter reportClientAdapter;

        public ReportConsoleReader(ReportClientAdapter reportClientAdapter)
        {
            this.reportClientAdapter = reportClientAdapter;
        }

        private static readonly Dictionary<string, string> infos = new Dictionary<string, string>
    {
        { "startTime", "start time" },
        { "endTime", "end time" },
        { "tagId", "tag ID" },
        { "priority", "priority" }
    };

        private static readonly Dictionary<string, string> errors = new Dictionary<string, string>
    {
        { "startTime", "Invalid start time" },
        { "endTime", "Invalid end time" },
        { "tagId", "Invalid tag ID" },
        { "priority", "Invalid priority" }
    };

        public static (DateTime startTime, DateTime endTime) GetTagValuesByPeriod()
        {
            var startTime = ReadDateTime(infos["startTime"], errors["startTime"]);
            var endTime = ReadDateTime(infos["endTime"], errors["endTime"]);

            return (startTime, endTime);
        }

        public static int GetTagValuesById()
        {
            var tagId = ConsoleReader.ReadPositiveInteger(infos["tagId"], errors["tagId"]);
            return tagId;
        }

        public static (DateTime startTime, DateTime endTime) GetAlarmsByPeriod()
        {
            var startTime = ReadDateTime(infos["startTime"], errors["startTime"]);
            var endTime = ReadDateTime(infos["endTime"], errors["endTime"]);

            return (startTime, endTime);
        }

        public static int GetAlarmsByPriority()
        {
            int priority = ConsoleReader.ReadPositiveInteger(infos["priority"], errors["priority"]);

            return priority;
        }

        private static DateTime ReadDateTime(string info, string error)
        {
            int year = ConsoleReader.ReadPositiveInteger($"Enter {info} year: ", error);
            int month = ConsoleReader.ReadPositiveInteger($"Enter {info} month: ", error);
            int day = ConsoleReader.ReadPositiveInteger($"Enter {info} day: ", error);
            int hour = ConsoleReader.ReadPositiveInteger($"Enter {info} hour: ", error);

            return new DateTime(year, month, day, hour, 0, 0);
        }
    }
}
