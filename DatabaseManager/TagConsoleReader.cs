using CommonLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.ConsoleTools;
using CommonLibrary.Model.Enum;

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
            { "unit", "unit" }
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
            { "dvalue", "Must be 0 or 1" }
        };

        private static readonly List<string> drivers = new List<string>
        {
            "RTU",
            "SD"
        };

        private static readonly string driverMenu = @"
                +------- DRIVER -------+
                |1) Real Time Unit     |
                |2) Simulation Driver  |
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

            return new AnalogInput(name, desc, address, syncTime, isSyncOn, low, high, unit, (DriverType)Enum.Parse(typeof(DriverType), driver, true), new List<Alarm>());
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

            return new DigitalOutput(name, desc, address,value);
        }
    }
}
