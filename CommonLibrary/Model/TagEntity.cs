using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CommonLibrary.Model
{
    [DataContract]
    public class TagEntity
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string TagName { get; set; }

        [DataMember]
        public double Value { get; set; }

        [DataMember]
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"{$"[{Type}]",-12} {$"{TagName}:",-17} {Math.Round(Value, 3),-10} [{Timestamp}]";
        }

    }
}
