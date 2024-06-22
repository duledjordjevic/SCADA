using System.Runtime.Serialization;

namespace CommonLibrary.Model
{
    [DataContract]
    public class DigitalOutput : OutputTag
    {
        public DigitalOutput(string name, string description, string address, double value) : base(name, description, address, value)
        {
        }

        public DigitalOutput()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
