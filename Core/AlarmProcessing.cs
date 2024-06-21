using CommonLibrary.Model;
using CommonLibrary.Model.Enum;
using Core.Model;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class AlarmProcessing
    {
        public delegate void TriggeredAlarmDelegate(ActivatedAlarm alarm, double value);
        public static event TriggeredAlarmDelegate OnAlarmTriggered;

        static List<ActivatedAlarm> activatedAlarms = new List<ActivatedAlarm>();

        static readonly object alarmsLock = new object();

        private static readonly int DELAY = 10;

        public static void TryTriggerAlarms(AnalogInput analogTag, double newValue)
        {
            foreach (Alarm alarm in analogTag.Alarms)
            {
                bool shouldTrigger =
                (alarm.PriorityType == AlarmPriorityType.HIGH && newValue > analogTag.HighLimit - alarm.Threshold) ||
                (alarm.PriorityType == AlarmPriorityType.LOW && newValue < analogTag.LowLimit + alarm.Threshold);

                if (shouldTrigger)
                {
                    TriggerAlarm(new ActivatedAlarm(alarm), newValue);
                }
            }
        }

        public static void TriggerAlarm(ActivatedAlarm newAlarm, double newValue)
        {
            if (HasActiveAlarm(newAlarm)) { return; }

            OnAlarmTriggered?.Invoke(newAlarm, newValue);

            lock (alarmsLock)
            {
                activatedAlarms.Add(newAlarm);
            }

            AlarmLogger.LogAlarm(newAlarm);
            AlarmRepository.Add(newAlarm);
        }

        private static bool HasActiveAlarm(ActivatedAlarm newAlarm)
        {
            return activatedAlarms.Any(alarm =>
                newAlarm.Alarm.TagName == alarm.Alarm.TagName &&
                newAlarm.Alarm.PriorityType == alarm.Alarm.PriorityType &&
                (newAlarm.TriggeredOn - alarm.TriggeredOn).TotalSeconds < DELAY);
        }
    }
}
