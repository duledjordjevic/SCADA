using CommonLibrary.Model;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Core.Repository
{
    public class TagWriter
    {
        public static List<XElement> GetXmlAnalogInputs(List<AnalogInput> analogInputs)
        {
            return analogInputs.Select(tag =>
            {
                var aiElement = new XElement("AI",
                    new XAttribute("name", tag.Name ?? "Unknown"),
                    new XAttribute("address", tag.Address ?? "0"),
                    new XAttribute("syncTime", tag.SyncTime),
                    new XAttribute("isSyncTurned", tag.IsSyncTurned.ToString().ToLower()),
                    // new XAttribute("driver", tag.Driver ?? "Unknown"), // Ako imate atribut driver
                    new XAttribute("lowLimit", tag.LowLimit),
                    new XAttribute("highLimit", tag.HighLimit),
                    new XAttribute("unit", tag.Unit ?? "unknown")
                );

                if (!string.IsNullOrWhiteSpace(tag.Description))
                {
                    aiElement.Add(new XElement("description", tag.Description));
                }

                if (tag.Alarms != null && tag.Alarms.Any())
                {
                    var alarmsElement = new XElement("alarms",
                        tag.Alarms.Select(alarm =>
                            new XElement("alarm",
                                new XAttribute("priorityType", alarm.PriorityType.ToString()),
                                new XAttribute("priority", alarm.Priority),
                                new XAttribute("threshold", alarm.Threshold)
                            )
                        )
                    );

                    aiElement.Add(alarmsElement);
                }

                return aiElement;
            }).ToList();
        }

        public static List<XElement> GetXmlAnalogOutputs(List<AnalogOutput> analogOutputs)
        {
            return analogOutputs.Select(output =>
            {
                var aoElement = new XElement("AO",
                    new XAttribute("name", output.Name ?? "Unknown"),
                    new XAttribute("address", output.Address ?? "0"),
                    new XAttribute("value", output.Value),
                    new XAttribute("lowLimit", output.LowLimit),
                    new XAttribute("highLimit", output.HighLimit),
                    new XAttribute("unit", output.Unit ?? "unknown")
                );

                if (!string.IsNullOrWhiteSpace(output.Description))
                {
                    aoElement.Add(new XElement("description", output.Description));
                }

                return aoElement;
            }).ToList();
        }

        public static List<XElement> GetXmlDigitalInputs(List<DigitalInput> digitalInputs)
        {
            return digitalInputs.Select(input =>
            {
                var diElement = new XElement("DI",
                    new XAttribute("name", input.Name ?? "Unknown"),
                    new XAttribute("address", input.Address ?? "0"),
                    new XAttribute("syncTime", input.SyncTime),
                    new XAttribute("isSyncTurned", input.IsSyncTurned.ToString().ToLower())
                );

                if (!string.IsNullOrWhiteSpace(input.Description))
                {
                    diElement.Add(new XElement("description", input.Description));
                }

                return diElement;
            }).ToList();
        }

        public static List<XElement> GetXmlDigitalOutputs(List<DigitalOutput> digitalOutputs)
        {
            return digitalOutputs.Select(output =>
            {
                var doElement = new XElement("DO",
                    new XAttribute("name", output.Name ?? "Unknown"),
                    new XAttribute("address", output.Address ?? "0"),
                    new XAttribute("value", output.Value)
                );

                if (!string.IsNullOrWhiteSpace(output.Description))
                {
                    doElement.Add(new XElement("description", output.Description));
                }

                return doElement;
            }).ToList();
        }


    }
}
