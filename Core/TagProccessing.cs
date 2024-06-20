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
using System.Threading;
using Core.Model;

namespace Core
{
    
    public class TagProccessing
    {
        //PATHS
        static readonly string TAGS_CONFIG_PATH = @"..\..\scadaConfig.xml";
        static readonly string ALARMS_LOG_PATH = @"..\..\alarmsLog.txt";

        //LOCKS
        static readonly object tagsConfigLock = new object();
        static readonly object tagsLock = new object();
        static readonly object activatedAlarmsLock = new object();
        static readonly object alarmsLogPathLock = new object();
        static readonly object activatedAlarmsDBLock = new object();

        //LISTS OF ALL TAGS
        public static List<AnalogInput> analogInputs = new List<AnalogInput>();
        public static List<AnalogOutput> analogOutputs = new List<AnalogOutput>();
        public static List<DigitalInput> digitalInputs = new List<DigitalInput>();
        public static List<DigitalOutput> digitalOutputs = new List<DigitalOutput>();

        //CURRENT VALUES
        static Dictionary<string, Thread> tagThreads = new Dictionary<string, Thread>();
        static Dictionary<string, double> currentValues = new Dictionary<string, double>();
        static List<ActivatedAlarm> activatedAlarms = new List<ActivatedAlarm>();


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


        public static void StartThreads()
        {
            var allInputTags = analogInputs.Cast<InputTag>()
                     .Concat(digitalInputs.Cast<InputTag>());
            foreach (var tag in allInputTags)
            {
                Thread thread = new Thread(() => { SimulateInput(tag); });
                tagThreads[tag.Name] = thread;
                thread.Start();
            }
        }

        private static void SimulateInput(InputTag inputTag)
        {
            while (true)
            {
                if (!inputTag.IsSyncTurned)
                {
                    Thread.Sleep(inputTag.SyncTime * 1000);
                    continue;
                }

                double newValue = inputTag.Driver.GetValue(inputTag);

                if (inputTag is AnalogInput analogTag)
                {
                    if (newValue >= analogTag.LowLimit && newValue <= analogTag.HighLimit)
                    {
                        lock (tagsLock)
                        {
                            currentValues[inputTag.Name] = newValue;
                        }
                        SaveTagConfiguration();
                    }

                    CheckAndActivateAlarms(analogTag, newValue);

                }
                else
                {
                    newValue = newValue < 0 ? 0 : 1;
                    if (newValue != currentValues[inputTag.Name])
                    {
                        lock (tagsLock)
                        {
                            currentValues[inputTag.Name] = newValue;
                        }
                        SaveTagConfiguration();
                    }
                }
            }

        }

        private static void CheckAndActivateAlarms(AnalogInput analogTag, double newValue)
        {
            foreach (Alarm alarm in analogTag.Alarms)
            {
                if ((alarm.PriorityType == AlarmPriorityType.HIGH && newValue > analogTag.HighLimit + alarm.Threshold)
                    || (alarm.PriorityType == AlarmPriorityType.LOW && newValue < analogTag.LowLimit - alarm.Threshold))
                {
                    ActivateAlarm(new ActivatedAlarm(alarm));
                }
            }
        }


        private static void ActivateAlarm(ActivatedAlarm activatedAlarm) 
        { 
            foreach (ActivatedAlarm existingAlarm in activatedAlarms)
            {
                var timeDifference = (activatedAlarm.TriggeredOn - existingAlarm.TriggeredOn).TotalSeconds;
                if (activatedAlarm.Alarm.TagName == existingAlarm.Alarm.TagName &&
                    activatedAlarm.Alarm.PriorityType == existingAlarm.Alarm.PriorityType && timeDifference < 10)
                {
                    return; 
                }
            }

            lock(activatedAlarmsLock)
            {
                activatedAlarms.Add(activatedAlarm);
            }
            lock (alarmsLogPathLock)
            {
                using (StreamWriter writer = File.AppendText(ALARMS_LOG_PATH))
                {
                    writer.WriteLine(activatedAlarm.ToString());
                }
            }
        }

        private static void SaveActivatedAlarmInDB(ActivatedAlarm activatedAlarm)
        {
            lock (activatedAlarmsDBLock)
            {
                using (var db = new DatabaseContext())
                {
                    db.ActivatedAlarms.Add(activatedAlarm);
                    db.SaveChanges();
                }
            }
        }
    }


}
