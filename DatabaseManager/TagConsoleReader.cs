using CommonLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            { "name", "" },
            { "desc", "" },
            { "address", "" },
            { "syncTime", "" },
            { "value", "value" },
            { "isSyncOn", "" },
            { "driver", "" },
            { "lowLimit", "" },
            { "highLimit", "" },
            { "unit", "" }
        };

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

            return new AnalogInput(name, desc, address, syncTime, isSyncOn, low, high, unit, null);
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

            return new DigitalInput(name, desc, address, syncTime, isSyncOn);
        }

        public static DigitalOutput ReadDO()
        {
            var name = ConsoleReader.ReadString(infos["name"], errors["name"]);
            var desc = ConsoleReader.ReadString(infos["desc"], errors["desc"]);
            var address = ConsoleReader.ReadString(infos["address"], errors["address"]);
            var value = ConsoleReader.ReadPositiveInteger(infos["value"], errors["value"]);

            return new DigitalOutput(name, desc, address,value);
        }
    }
}
