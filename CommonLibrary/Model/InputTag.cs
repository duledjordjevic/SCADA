using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    [DataContract]
    public abstract class InputTag : Tag
    {
        protected InputTag(string name, string description, string address, int syncTime, bool isSyncOn) : base(name, description, address)
        {
            SyncTime = syncTime;
            IsSyncTurned = isSyncOn;
        }

        [DataMember]
        public int SyncTime { get; set; }

        [DataMember]
        public bool IsSyncTurned { get; set; }
        //public Driver Driver { get; set; }


    }
}
