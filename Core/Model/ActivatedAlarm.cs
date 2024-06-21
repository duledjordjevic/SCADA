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

        public ActivatedAlarm() { }
        public ActivatedAlarm(Alarm alarm)
        {
            Alarm = alarm;
            TriggeredOn = DateTime.Now;
        }

        public override string ToString()
        {
            return $"ActivatedAlarm [Id={Id}, " +
                   $"Alarm={(Alarm?.ToString() ?? "null")}, " +
                   $"TriggeredOn={TriggeredOn:yyyy-MM-dd HH:mm:ss}]";
        }
    }
}
