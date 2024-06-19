using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    [DataContract]
    public abstract class OutputTag : Tag
    {
        [DataMember]
        public double Value { get; set; }
    }
}
