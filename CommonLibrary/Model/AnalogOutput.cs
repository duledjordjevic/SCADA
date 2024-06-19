using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    [DataContract]
    public class AnalogOutput : OutputTag
    {
        [DataMember]
        public double LowLimit { get; set; }

        [DataMember]
        public double HighLimit { get; set; }

        [DataMember]
        public string Unit {  get; set; }
    }
}
