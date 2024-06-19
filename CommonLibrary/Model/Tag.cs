using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    [DataContract]
    public abstract class Tag
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Address { get; set; }

        protected Tag(string name, string description, string address)
        {
            Name = name;
            Description = description;
            Address = address;
        }
    }
}
