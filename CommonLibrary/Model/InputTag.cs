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
        [DataMember]
        public int SyncTime { get; set; }

        [DataMember]
        public bool IsSyncTurned { get; set; }
        //public Driver Driver { get; set; }
    }
}
