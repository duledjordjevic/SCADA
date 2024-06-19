using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class AnalogInput : InputTag
    {
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Unit {  get; set; }
        public List<Alarm> Alarms { get; set; }

        public AnalogInput() 
        {
            Alarms = new List<Alarm>();
        }

        public void AddAlarm(Alarm alarm)
        {
            Alarms.Add(alarm);
        }

    }
}
