﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Core.Model
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
            return $"TagEntity [Id={Id}, Type={Type}, TagName={TagName}, Value={Value}, Timestamp={Timestamp:yyyy-MM-dd HH:mm:ss}]";
        }

    }
}
