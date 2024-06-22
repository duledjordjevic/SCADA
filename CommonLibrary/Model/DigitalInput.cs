using CommonLibrary.Model.Enum;
using System.Runtime.Serialization;

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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
