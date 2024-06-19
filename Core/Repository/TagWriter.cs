using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Core.Model;

namespace Core.Repository
{
    public class TagWriter
    {
        public static List<XElement> GetXmlAnalogInputs(List<AnalogInput> analogInputs)
        {
            return analogInputs.Select(tag => new XElement("AI",
                new XAttribute("name", tag.Name),
                new XAttribute("address", tag.Address),
                new XAttribute("syncTime", tag.SyncTime),
                new XAttribute("isSyncTurned", tag.IsSyncTurned.ToString().ToLower()),
                //new XAttribute("driver", tag.Driver),
                new XAttribute("lowLimit", tag.LowLimit),
                new XAttribute("highLimit", tag.HighLimit),
                new XAttribute("unit", tag.Unit),
                new XElement("description", tag.Description),
                new XElement("alarms",
                    tag.Alarms.Select(alarm =>
                        new XElement("alarm",
                            new XAttribute("priorityType", alarm.PriorityType.ToString()),
                            new XAttribute("priority", alarm.Priority),
                            new XAttribute("threshold", alarm.Threshold)
                        )
                    )
                )
            )).ToList();
        }

        public static List<XElement> GetXmlAnalogOutputs(List<AnalogOutput> analogOutputs)
        {
            return analogOutputs.Select(output => new XElement("AO",
                new XAttribute("name", output.Name),
                new XAttribute("address", output.Address),
                new XAttribute("value", output.Value),
                new XAttribute("lowLimit", output.LowLimit),
                new XAttribute("highLimit", output.HighLimit),
                new XAttribute("unit", output.Unit),
                new XElement("description", output.Description)
            )).ToList();
        }

        public static List<XElement> GetXmlDigitalInputs(List<DigitalInput> digitalInputs)
        {
            return digitalInputs.Select(input => new XElement("DI",
                new XAttribute("name", input.Name),
                new XAttribute("address", input.Address),
                new XAttribute("syncTime", input.SyncTime),
                new XAttribute("isSyncTurned", input.IsSyncTurned.ToString().ToLower()),
                new XAttribute("driver", input.Driver),
                new XElement("description", input.Description)
            )).ToList();
        }

        public static List<XElement> GetXmlDigitalOutputs(List<DigitalOutput> digitalOutputs)
        {
            return digitalOutputs.Select(output => new XElement("DO",
                new XAttribute("name", output.Name),
                new XAttribute("address", output.Address),
                new XAttribute("value", output.Value),
                new XElement("description", output.Description)
            )).ToList();
        }
    }
}
