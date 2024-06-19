using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    [DataContract]
    public class AnalogInput : InputTag
    {
        [DataMember]
        public double LowLimit { get; set; }

        [DataMember]
        public double HighLimit { get; set; }

        [DataMember]
        public string Unit {  get; set; }

        [DataMember]
        public List<Alarm> Alarms { get; set; }



        public AnalogInput() 
        {
            Alarms = new List<Alarm>();
        }

        public void AddAlarm(Alarm alarm)
        {
            Alarms.Add(alarm);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Unit: {Unit}";
        }
    }
}
