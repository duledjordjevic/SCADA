using CommonLibrary.Model;
using CommonLibrary.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Core.Repository;
using System.IO;

namespace Core
{
    
    public class TagProccessing
    {
        static readonly string TAGS_CONFIG_PATH = @"E:\Faks\6.semestar\Softver nadzorno-upravljackih sistema\Projekat\SCADA\Core\scadaConfig.xml";

        static readonly object tagsConfigLock = new object();

        public static List<AnalogInput> analogInputs = new List<AnalogInput>();
        static List<AnalogOutput> analogOutputs = new List<AnalogOutput>();
        static List<DigitalInput> digitalInputs = new List<DigitalInput>();
        static List<DigitalOutput> digitalOutputs = new List<DigitalOutput>();

        

        public static void LoadTags()
        {
            XElement xmlData = XElement.Load(TAGS_CONFIG_PATH);
            analogInputs = TagReader.LoadAnalogInputs(xmlData.Descendants("AI"));
            analogOutputs = TagReader.LoadAnalogOutputs(xmlData.Descendants("AO"));
            digitalInputs = TagReader.LoadDigitalInputs(xmlData.Descendants("DI"));
            digitalOutputs = TagReader.LoadDigitalOutputs(xmlData.Descendants("DO"));
        }

        public static void SaveTagConfiguration()
        {
            var analogInputsXml = TagWriter.GetXmlAnalogInputs(analogInputs);
            var analogOutputsXml = TagWriter.GetXmlAnalogOutputs(analogOutputs);
            var digitalInputsXml = TagWriter.GetXmlDigitalInputs(digitalInputs);
            var digitalOutputsXml = TagWriter.GetXmlDigitalOutputs(digitalOutputs);

            var tagsXml = new XElement("tags");
            tagsXml.Add(analogInputsXml);
            tagsXml.Add(analogOutputsXml);
            tagsXml.Add(digitalInputsXml);
            tagsXml.Add(digitalOutputsXml);

            lock(tagsConfigLock)
            {
                using (var writer = new StreamWriter(TAGS_CONFIG_PATH))
                {
                    writer.Write(tagsXml);
                }
            }
        }




    }
}
