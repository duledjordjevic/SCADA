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
using Core.Service;
using System.Xml;
using System.Data.Entity;
using Google.Protobuf.WellKnownTypes;

namespace Core
{
    
    public class TagProccessing
    {
        //PATHS
        static readonly string TAGS_CONFIG_PATH = @"..\..\scadaConfig.xml";
        static readonly string ALARMS_LOG_PATH = @"..\..\alarmsLog.txt";

        //LOCKS
        static readonly object tagsConfigLock = new object();
        static readonly object currentValuesLock = new object();
        static readonly object activatedAlarmsLock = new object();
        static readonly object alarmsLogPathLock = new object();
        static readonly object activatedAlarmsDBLock = new object();
        static readonly object tagValuesDBLock = new object();
        static readonly object tagsLock = new object();

        //LISTS OF ALL TAGS
        public static List<AnalogInput> analogInputs = new List<AnalogInput>();
        public static List<AnalogOutput> analogOutputs = new List<AnalogOutput>();
        public static List<DigitalInput> digitalInputs = new List<DigitalInput>();
        public static List<DigitalOutput> digitalOutputs = new List<DigitalOutput>();

        //CURRENT VALUES
        static Dictionary<string, Thread> tagThreads = new Dictionary<string, Thread>();
        static Dictionary<string, double> currentValues = new Dictionary<string, double>();
        static List<ActivatedAlarm> activatedAlarms = new List<ActivatedAlarm>();

        //EVENTS
        public delegate void TagValueChangedDelegate(InputTag tag, double value);
        public delegate void AlarmTriggeredDelegate(ActivatedAlarm alarm, double value);

        public static event TagValueChangedDelegate OnTagValueChanged;
        public static event AlarmTriggeredDelegate OnAlarmTriggered;


        public static void LoadTags()
        {
            XElement xmlData = XElement.Load(TAGS_CONFIG_PATH);
            analogInputs = TagReader.LoadAnalogInputs(xmlData.Descendants("AI"));
            analogOutputs = TagReader.LoadAnalogOutputs(xmlData.Descendants("AO"));
            digitalInputs = TagReader.LoadDigitalInputs(xmlData.Descendants("DI"));
            digitalOutputs = TagReader.LoadDigitalOutputs(xmlData.Descendants("DO"));

            var allTags = analogInputs.Cast<Tag>()
                            .Concat(analogOutputs.Cast<Tag>())
                            .Concat(digitalInputs.Cast<Tag>())
                            .Concat(digitalOutputs.Cast<Tag>());

            foreach(var tag in allTags)
            {
                lock (currentValuesLock)
                {
                    currentValues[tag.Name] = (tag is OutputTag outTag) ? outTag.Value : 0;
                }
            }
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

            var xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                tagsXml 
            );

            lock (tagsConfigLock)
            {
                using (var stream = new FileStream(TAGS_CONFIG_PATH, FileMode.Create))
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Encoding = Encoding.UTF8; 
                    settings.Indent = true; 

                    using (XmlWriter writer = XmlWriter.Create(stream, settings))
                    {
                        xmlDocument.Save(writer);
                    }
                }
            }
        }

        public static bool AddTag(Tag tag)
        {
            if (IsTagAleradyExist(tag.Name)) return false;

            lock (tagsLock) 
            { 
                if (tag is AnalogInput analogInput)
                {
                    analogInputs.Add(analogInput);
                    StartSingleThread(analogInput);
                }
                else if(tag is AnalogOutput analogOutput)
                {
                    analogOutputs.Add(analogOutput);
                
                }
                else if(tag is DigitalInput digitalInput)
                {
                    digitalInputs.Add(digitalInput);
                    StartSingleThread(digitalInput);
                }
                else if(tag is DigitalOutput digitalOutput)
                {
                    digitalOutputs.Add(digitalOutput);

                }
            }


            lock (currentValuesLock)
            {
                currentValues[tag.Name] = (tag is OutputTag outTag) ? outTag.Value : 0;
            }

            SaveTagConfiguration();

            return true;
        }

        public static bool RemoveTag(string tagName)
        {
            bool isRemoved;
            lock (tagsLock)
            {
                isRemoved = analogInputs.RemoveAll(tag => tag.Name == tagName) > 0 ||
                           analogOutputs.RemoveAll(tag => tag.Name == tagName) > 0 ||
                           digitalInputs.RemoveAll(tag => tag.Name == tagName) > 0 ||
                           digitalOutputs.RemoveAll(tag => tag.Name == tagName) > 0;
            }

            if(isRemoved)
            {
                if (tagThreads.TryGetValue(tagName, out var thread))
                {
                    try
                    {
                        tagThreads[tagName].Abort();
                    }
                    finally
                    {
                        tagThreads.Remove(tagName);
                    }
                }

                SaveTagConfiguration();

                lock (tagValuesDBLock)
                {
                    using (var db = new DatabaseContext())
                    {
                        foreach (TagEntity entity in db.TagValues.Where(entity => entity.TagName == tagName).ToList())
                        {
                            db.TagValues.Remove(entity);
                        }
                        db.SaveChanges();
                    }
                }

                lock (activatedAlarmsDBLock)
                {
                    using (var db = new DatabaseContext())
                    {
                        foreach (ActivatedAlarm alarm in db.ActivatedAlarms.Where(alarm => alarm.Alarm.TagName == tagName).ToList())
                        {
                            db.ActivatedAlarms.Remove(alarm);
                        }
                        db.SaveChanges();
                    }
                }

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
        public static InputTag FindInputTagByName(string name)
        {
            var allTags = analogInputs.Cast<InputTag>()
                            .Concat(digitalInputs.Cast<InputTag>());

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
                StartSingleThread(tag);
            }
        }

        private static void StartSingleThread(InputTag tag)
        {
            Thread thread = new Thread(() => { SimulateInput(tag); });
            tagThreads[tag.Name] = thread;
            thread.Start();
        }

        private static void SimulateInput(InputTag inputTag)
        {
            while (true)
            {
                if (inputTag.IsSyncTurned)
                {
                    double newValue = GetValueFromDriver(inputTag);

                    if (inputTag is AnalogInput analogTag)
                    {
                        if (newValue >= analogTag.LowLimit && newValue <= analogTag.HighLimit)
                        {
                            lock (currentValuesLock)
                            {
                                currentValues[inputTag.Name] = newValue;
                            }

                            OnTagValueChanged?.Invoke(inputTag, newValue);
                            SaveTagConfiguration();
                            SaveTagCurrentValueInDB((Tag)inputTag, newValue);
                        }

                        CheckAndActivateAlarms(analogTag, newValue);

                    }
                    else
                    {
                        newValue = newValue < 0 ? 0 : 1;
                        if (newValue != currentValues[inputTag.Name])
                        {
                            lock (currentValuesLock)
                            {
                                currentValues[inputTag.Name] = newValue;
                            }

                            OnTagValueChanged?.Invoke(inputTag, newValue);
                            SaveTagConfiguration();
                            SaveTagCurrentValueInDB((Tag)inputTag, newValue);
                        }
                    }
                    Thread.Sleep(inputTag.SyncTime * 1000);
                }
            }

        }

        private static double GetValueFromDriver(InputTag inputTag)
        {
            switch (inputTag.Type)
            {
                case (DriverType.RTU):
                    return RealTimeDriverService.GetValue(inputTag.Address);
                case (DriverType.SD):
                    //return SimulationDriverService.GetValue(inputTag.Address);
                    break;
            }

            return 0;
        }

        private static void CheckAndActivateAlarms(AnalogInput analogTag, double newValue)
        {
            foreach (Alarm alarm in analogTag.Alarms)
            {
                if ((alarm.PriorityType == AlarmPriorityType.HIGH && newValue > analogTag.HighLimit + alarm.Threshold)
                    || (alarm.PriorityType == AlarmPriorityType.LOW && newValue < analogTag.LowLimit - alarm.Threshold))
                {
                    ActivateAlarm(new ActivatedAlarm(alarm), newValue);
                }
            }
        }


        private static void ActivateAlarm(ActivatedAlarm activatedAlarm, double newValue) 
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

            OnAlarmTriggered?.Invoke(activatedAlarm, newValue);

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
            SaveActivatedAlarmInDB(activatedAlarm);
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


        private static void SaveTagCurrentValueInDB(Tag tag, double value)
        {
            lock (tagValuesDBLock)
            {
                using (var db = new DatabaseContext())
                {
                    db.TagValues.Add(new TagEntity
                    {
                        Type = tag.GetType().Name,
                        TagName = tag.Name,
                        Value = value,
                        Timestamp = DateTime.Now
                    });
                    db.SaveChanges();
                }
            }
        }


        public static bool ToggleScan(string tagName)
        {
            lock (tagsLock)
            {
                var tag = FindInputTagByName(tagName);
                if (tag == null)
                {
                    return false;
                }
                tag.IsSyncTurned = !tag.IsSyncTurned;
                SaveTagConfiguration();
            }

            return true;
        }








    }


}
