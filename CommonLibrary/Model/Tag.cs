using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    [DataContract]
    [KnownType(typeof(OutputTag))]
    [KnownType(typeof(InputTag))]
    public class Tag
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Address { get; set; }

        public Tag(string name, string description, string address)
        {
            Name = name;
            Description = description;
            Address = address;
        }

        public Tag()
        {
        }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, Address: {Address}";
        }

    }
}
