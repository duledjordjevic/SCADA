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
    [KnownType(typeof(AnalogInput))]
    [KnownType(typeof(DigitalInput))]
    public class InputTag : Tag
    {
        public InputTag(string name, string description, string address, int syncTime, bool isSyncOn, DriverType driverType) : base(name, description, address)
        {
            Type = driverType;
            SyncTime = syncTime;
            IsSyncTurned = isSyncOn;
        }

        [DataMember]
        public int SyncTime { get; set; }

        [DataMember]
        public bool IsSyncTurned { get; set; }

        [DataMember]
        public DriverType Type { get; set; }

        [DataMember]
        public IDriver Driver { get; set; }

        public InputTag()
        {
            
        }

    }
}
