using CommonLibrary.Model;
using CommonLibrary.Model.Enum;
using Core.Model;
using Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class AlarmProcessing
    {
        public delegate void TriggeredAlarmDelegate(ActivatedAlarm alarm);
        public static event TriggeredAlarmDelegate OnAlarmTriggered;

        static List<ActivatedAlarm> activatedAlarms = new List<ActivatedAlarm>();

        static readonly object alarmsLock = new object();

        private static readonly int DELAY = 10;

        public static void TryTriggerAlarms(AnalogInput tag, double newValue)
        {
            foreach (Alarm alarm in tag.Alarms)
            {
                bool shouldTrigger =
                (alarm.PriorityType == AlarmPriorityType.HIGH && newValue > tag.HighLimit - alarm.Threshold) ||
                (alarm.PriorityType == AlarmPriorityType.LOW && newValue < tag.LowLimit + alarm.Threshold);

                if (shouldTrigger)
                {
                    TriggerAlarm(new ActivatedAlarm(alarm, newValue));
                }
            }
        }

        public static void TriggerAlarm(ActivatedAlarm newAlarm)
        {
            if (HasActiveAlarm(newAlarm)) { return; }

            OnAlarmTriggered?.Invoke(newAlarm);

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
