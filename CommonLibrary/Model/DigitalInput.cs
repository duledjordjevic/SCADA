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
    public class DigitalInput : InputTag
    {
        public DigitalInput(string name, string description, string address, int syncTime, bool isSyncOn, DriverType driverType) : base(name, description, address, syncTime, isSyncOn, driverType)
        {
        }

        public DigitalInput()
        {
            
        }
    }
}
