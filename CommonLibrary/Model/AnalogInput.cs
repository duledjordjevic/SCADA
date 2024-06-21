using CommonLibrary.Model.Enum;
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
        public string Unit { get; set; }

        [DataMember]
        public List<Alarm> Alarms { get; set; }

        public AnalogInput(string name, string description, string address, int syncTime, bool isSyncOn, double low, double high, string unit, DriverType driverType,  List<Alarm> alarms) : base(name, description, address, syncTime, isSyncOn, driverType)
        {
            LowLimit = low;
            HighLimit = high;
            Unit = unit;
            Alarms = alarms;

        }

        public AnalogInput() {}
        public AnalogInput(string name, string description,string address, bool isSyncTurned, int syncTime, double lowLimit, double highLimit, string unit, List<Alarm> alarms)
        {
            Name = name;
            Description = description;
            Address = address;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Unit = unit;
            Alarms = alarms;
            SyncTime = syncTime;
            IsSyncTurned = isSyncTurned;
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
