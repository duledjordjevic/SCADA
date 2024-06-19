using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    [DataContract]
    public class DigitalOutput : OutputTag
    {
        public DigitalOutput(string name, string description, string address, double value) : base(name, description, address, value)
        {
        }
    }
}
