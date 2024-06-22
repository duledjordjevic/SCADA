using CommonLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
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
            return $"{Alarm.TagName}: {Value} - {Alarm.PriorityType} [{TriggeredOn}]";
        }
    }
}
