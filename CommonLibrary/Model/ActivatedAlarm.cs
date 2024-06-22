using CommonLibrary.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CommonLibrary.Model
{
    [DataContract]
    public class ActivatedAlarm
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        public Alarm Alarm { get; set; }

        [DataMember]
        public DateTime TriggeredOn { get; set; }

        [DataMember]
        public double Value { get; set; }

        public ActivatedAlarm() { }
        public ActivatedAlarm(Alarm alarm, double value)
        {
            Alarm = alarm;
            TriggeredOn = DateTime.Now;
            Value = value;
        }

        public override string ToString()
        {
            return $"{$"{Alarm.TagName}:",-17} {Math.Round(Value, 3),-10} {Alarm.PriorityType,-4} [{TriggeredOn}]";
        }
    }
}
