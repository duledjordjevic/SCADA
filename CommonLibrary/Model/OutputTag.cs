using System.Runtime.Serialization;

namespace CommonLibrary.Model
{
    [DataContract]
    [KnownType(typeof(AnalogOutput))]
    [KnownType(typeof(DigitalOutput))]
    public class OutputTag : Tag
    {
        [DataMember]
        public double Value { get; set; }

        public OutputTag(string name, string description, string address, double value) : base(name, description, address)
        {
            Value = value;
        }

        public OutputTag()
        {

        }

        public override string ToString()
        {
            return $"{base.ToString()}, Value: {Value}";
        }

    }
}
