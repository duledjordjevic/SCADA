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
        public AnalogOutput(string name, string description, string address, double value, double low, double high, string unit) : base(name, description, address, value)
        {
            LowLimit = low;
            HighLimit = high;
            Unit = unit;
        }

        [DataMember]
        public double LowLimit { get; set; }

        [DataMember]
        public double HighLimit { get; set; }

        [DataMember]
        public string Unit {  get; set; }

        public AnalogOutput()
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()}, LowLimit: {LowLimit}, HighLimit: {HighLimit}, Unit: {Unit}";
        }
    }
}
