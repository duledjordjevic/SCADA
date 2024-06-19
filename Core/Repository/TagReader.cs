using CommonLibrary.Model.Enum;
using CommonLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Repository
{
    public class TagReader
    {
        public static List<AnalogInput> LoadAnalogInputs(IEnumerable<XElement> xElements)
        {
            List<AnalogInput> analogInputs = new List<AnalogInput>();

            foreach (XElement tag in xElements)
            {
                AnalogInput analogInput = new AnalogInput
                {
                    Name = tag.Attribute("name")?.Value,
                    Address = tag.Attribute("address")?.Value,
                    SyncTime = int.Parse(tag.Attribute("syncTime")?.Value ?? "0"),
                    IsSyncTurned = bool.Parse(tag.Attribute("isSyncTurned")?.Value ?? "false"),
                    //Driver = (tag.Attribute("driver")?.Value == "RTU") ? new RealTimeDriver() : new SimulationDriver(),
                    LowLimit = double.Parse(tag.Attribute("lowLimit")?.Value ?? "0"),
                    HighLimit = double.Parse(tag.Attribute("highLimit")?.Value ?? "0"),
                    Unit = tag.Attribute("unit")?.Value,
                    Description = tag.Element("description")?.Value,
                    Alarms = null, 
                };

                foreach (XElement alarm in tag.Descendants("Alarms"))
                {
                    analogInput.AddAlarm(new Alarm
                    {
                        PriorityType = alarm.Attribute("priorityType")?.Value == "HIGH" ? AlarmPriorityType.HIGH : AlarmPriorityType.LOW,
                        Priority = int.Parse(alarm.Attribute("priority")?.Value ?? "1"),
                        Threshold = double.Parse(alarm.Attribute("threshold")?.Value ?? "0"),
                    });
                }

                analogInputs.Add(analogInput);
            }

            return analogInputs;
        }

        public static List<AnalogOutput> LoadAnalogOutputs(IEnumerable<XElement> xElements)
        {
            List<AnalogOutput> analogOutputs = new List<AnalogOutput>();

            foreach (XElement tag in xElements)
            {
                AnalogOutput analogOutput = new AnalogOutput
                {
                    Name = tag.Attribute("name")?.Value,
                    Address = tag.Attribute("address")?.Value,
                    //Driver = (tag.Attribute("driver")?.Value == "RTU") ? new RealTimeDriver() : new SimulationDriver(),
                    LowLimit = double.Parse(tag.Attribute("lowLimit")?.Value ?? "0"),
                    HighLimit = double.Parse(tag.Attribute("highLimit")?.Value ?? "0"),
                    Unit = tag.Attribute("unit")?.Value,
                    Description = tag.Element("description")?.Value,
                };

                analogOutputs.Add(analogOutput);
            }

            return analogOutputs;
        }

        public static List<DigitalInput> LoadDigitalInputs(IEnumerable<XElement> xElements)
        {
            List<DigitalInput> digitalInputs = new List<DigitalInput>();

            foreach (XElement tag in xElements)
            {
                DigitalInput digitalInput = new DigitalInput
                {
                    Name = tag.Attribute("name")?.Value,
                    Address = tag.Attribute("address")?.Value,
                    SyncTime = int.Parse(tag.Attribute("syncTime")?.Value ?? "0"),
                    IsSyncTurned = bool.Parse(tag.Attribute("isSyncTurned")?.Value ?? "false"),
                    //Driver = (tag.Attribute("driver")?.Value == "RTU") ? new RealTimeDriver() : new SimulationDriver(),
                    Description = tag.Element("description")?.Value
                };

                digitalInputs.Add(digitalInput);
            }

            return digitalInputs;
        }

        public static List<DigitalOutput> LoadDigitalOutputs(IEnumerable<XElement> xElements)
        {
            List<DigitalOutput> digitalOutputs = new List<DigitalOutput>();

            foreach (XElement tag in xElements)
            {
                DigitalOutput digitalOutput = new DigitalOutput
                {
                    Name = tag.Attribute("name")?.Value,
                    Address = tag.Attribute("address")?.Value,
                    //Driver = (tag.Attribute("driver")?.Value == "RTU") ? new RealTimeDriver() : new SimulationDriver(),
                    Description = tag.Element("description")?.Value,
                    Value = double.Parse(tag.Attribute("value")?.Value)
                };

                digitalOutputs.Add(digitalOutput);
            }

            return digitalOutputs;
        }
    }
}
