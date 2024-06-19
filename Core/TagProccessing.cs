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
        static readonly string TAGS_CONFIG_PATH = @"C:\Users\Administrator\Desktop\SCADA\Core\scadaConfig.xml";

        static readonly object tagsConfigLock = new object();

        public static List<AnalogInput> analogInputs = new List<AnalogInput>();
        public static List<AnalogOutput> analogOutputs = new List<AnalogOutput>();
        public static List<DigitalInput> digitalInputs = new List<DigitalInput>();
        public static List<DigitalOutput> digitalOutputs = new List<DigitalOutput>();

        

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

        public static bool AddTag(Tag tag)
        {
            if (IsTagAleradyExist(tag.Name)) return false;

            if(tag is AnalogInput analogInput)
            {
                analogInputs.Add(analogInput);
            }else if(tag is AnalogOutput analogOutput)
            {
                analogOutputs.Add(analogOutput);
            }else if(tag is DigitalInput digitalInput)
            {
                digitalInputs.Add(digitalInput);
            }
            else if(tag is DigitalOutput digitalOutput)
            {
                digitalOutputs.Add(digitalOutput);
            }

            SaveTagConfiguration();

            return true;
        }

        public static bool RemoveTag(string tagName)
        {
            var isRemoved = analogInputs.RemoveAll(tag => tag.Name == tagName) > 0 ||
                       analogOutputs.RemoveAll(tag => tag.Name == tagName) > 0 ||
                       digitalInputs.RemoveAll(tag => tag.Name == tagName) > 0 ||
                       digitalOutputs.RemoveAll(tag => tag.Name == tagName) > 0;

            if(isRemoved)
            {
                SaveTagConfiguration();
                return true;
            }

            return false;
        }


        public static Tag FindTagByName(string name)
        {
            var allTags = analogInputs.Cast<Tag>()
                            .Concat(analogOutputs.Cast<Tag>())
                            .Concat(digitalInputs.Cast<Tag>())
                            .Concat(digitalOutputs.Cast<Tag>());

            return allTags.FirstOrDefault(tag => tag.Name == name);
        }
        public static bool IsTagAleradyExist(string tagName)
        {
            return analogInputs.Any(tag => tag.Name == tagName) ||
           analogOutputs.Any(tag => tag.Name == tagName) ||
           digitalInputs.Any(tag => tag.Name == tagName) ||
           digitalOutputs.Any(tag => tag.Name == tagName);
        }

        public static List<string> GetAllTagNames(TagType type)
        {
            List<string> tagNames;

            switch (type)
            {
                case TagType.AI:
                    tagNames = analogInputs.Select(tag => tag.Name).ToList();
                    break;
                case TagType.AO:
                    tagNames = analogOutputs.Select(tag => tag.Name).ToList();
                    break;
                case TagType.DI:
                    tagNames = digitalInputs.Select(tag => tag.Name).ToList();
                    break;
                case TagType.DO:
                    tagNames = digitalOutputs.Select(tag => tag.Name).ToList();
                    break;
                default:
                    throw new ArgumentException("Invalid tag type");
            }

            return tagNames;

        }

    }
}
