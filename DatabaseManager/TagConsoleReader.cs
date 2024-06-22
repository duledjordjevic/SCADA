using CommonLibrary.ConsoleTools;
using CommonLibrary.Model;
using CommonLibrary.Model.Enum;
using System;
using System.Collections.Generic;

namespace DatabaseManager
{
    public class TagConsoleReader
    {
        private static readonly Dictionary<string, string> infos = new Dictionary<string, string>
        {
            { "name", "tag name" },
            { "desc", "description" },
            { "address", "address" },
            { "syncTime", "sync time" },
            { "value", "value" },
            { "isSyncOn", "Is sync on" },
            { "driver", "driver" },
            { "lowLimit", "lower limit" },
            { "highLimit", "upper limit" },
            { "unit", "unit" },
            { "threshold", "threshold" },
            { "priority", "priority" }

        };

        private static readonly Dictionary<string, string> errors = new Dictionary<string, string>
        {
            { "name", "Must be filled" },
            { "desc", "Must be filled" },
            { "address", "Must be filled" },
            { "syncTime", "Must be positive number" },
            { "value", "Must be number" },
            { "isSyncOn", "Must be (y/n)" },
            { "driver", "Must be selected" },
            { "lowLimit", "Must be number" },
            { "highLimit", "Must be greater than low" },
            { "unit", "Must be filled" },
            { "dvalue", "Must be 0 or 1" },
            { "threshold", "Must be number" },
            { "priority", "Must be 1 2 or 3" }
        };

        private static readonly List<string> drivers = new List<string>
        {
            "RTU",
            "SD"
        };

        private static readonly List<string> alarms = new List<string>
        {
            "LOW",
            "HIGH"
        };

        private static readonly string driverMenu = @"
                +------- DRIVER -------+
                |1) Real Time Unit     |
                |2) Simulation Driver  |
                +----------------------+
            ";

        private static readonly string alarmMenu = @"
                +------- ALARM --------+
                |1) Low limit          |
                |2) High limit         |
                +----------------------+
            ";

        public static AnalogInput ReadAI()
        {
            var name = ConsoleReader.ReadString(infos["name"], errors["name"]);
            var desc = ConsoleReader.ReadString(infos["desc"], errors["desc"]);
            var address = ConsoleReader.ReadString(infos["address"], errors["address"]);
            var syncTime = ConsoleReader.ReadPositiveInteger(infos["syncTime"], errors["syncTime"]);
            var isSyncOn = ConsoleReader.ReadBool(infos["isSyncOn"]);
            var low = ConsoleReader.ReadDouble(infos["lowLimit"], errors["lowLimit"]);
            var high = ConsoleReader.ReadDouble(infos["highLimit"], errors["highLimit"]);
            var unit = ConsoleReader.ReadString(infos["unit"], errors["unit"]);
            var driver = ConsoleReader.ReadMenuSelection(driverMenu, drivers);
            var alarms = ReadAlarms(name);

            return new AnalogInput(name, desc, address, syncTime, isSyncOn, low, high, unit, (DriverType)Enum.Parse(typeof(DriverType), driver, true), alarms);
        }

        public static AnalogOutput ReadAO()
        {
            var name = ConsoleReader.ReadString(infos["name"], errors["name"]);
            var desc = ConsoleReader.ReadString(infos["desc"], errors["desc"]);
            var address = ConsoleReader.ReadString(infos["address"], errors["address"]);
            var value = ConsoleReader.ReadPositiveInteger(infos["value"], errors["value"]);
            var low = ConsoleReader.ReadDouble(infos["lowLimit"], errors["lowLimit"]);
            var high = ConsoleReader.ReadDouble(infos["highLimit"], errors["highLimit"]);
            var unit = ConsoleReader.ReadString(infos["unit"], errors["unit"]);

            return new AnalogOutput(name, desc, address, value, low, high, unit);
        }

        public static DigitalInput ReadDI()
        {
            var name = ConsoleReader.ReadString(infos["name"], errors["name"]);
            var desc = ConsoleReader.ReadString(infos["desc"], errors["desc"]);
            var address = ConsoleReader.ReadString(infos["address"], errors["address"]);
            var syncTime = ConsoleReader.ReadPositiveInteger(infos["syncTime"], errors["syncTime"]);
            var isSyncOn = ConsoleReader.ReadBool(infos["isSyncOn"]);
            var driver = ConsoleReader.ReadMenuSelection(driverMenu, drivers);

            return new DigitalInput(name, desc, address, syncTime, isSyncOn, (DriverType)Enum.Parse(typeof(DriverType), driver, true));
        }

        public static DigitalOutput ReadDO()
        {
            var name = ConsoleReader.ReadString(infos["name"], errors["name"]);
            var desc = ConsoleReader.ReadString(infos["desc"], errors["desc"]);
            var address = ConsoleReader.ReadString(infos["address"], errors["address"]);
            var value = ConsoleReader.ReadZeroOrOne(infos["value"], errors["dvalue"]);

            return new DigitalOutput(name, desc, address, value);
        }

        public static Alarm ReadAlarm(string tagName)
        {

            var priorityType = ConsoleReader.ReadMenuSelection(alarmMenu, alarms);
            var threshold = ConsoleReader.ReadPositiveInteger(infos["threshold"], errors["threshold"]);
            var priority = ConsoleReader.ReadFromList(infos["priority"], errors["priority"], new List<int>() { 1, 2, 3});

            var alarm = new Alarm((AlarmPriorityType)Enum.Parse(typeof(AlarmPriorityType), priorityType, true), priority, threshold, tagName);

            return alarm;
        }

        public static List<Alarm> ReadAlarms(string tagName)
        {
            var alarms = new List<Alarm>();
            while (true)
            {
                var input = ConsoleReader.ReadBool("Add new alarm");
                if (input)
                {
                   alarms.Add(ReadAlarm(tagName));

                } else { break; }
            }

            return alarms;
        }

    }
}
