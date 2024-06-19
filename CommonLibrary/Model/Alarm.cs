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
    public class Alarm
    {
        [DataMember]
        public AlarmPriorityType PriorityType { get; set; }

        [DataMember]
        public int Priority { get; set; }

        [DataMember]
        public double Threshold { get; set; }

        public Alarm() { }
        public Alarm(AlarmPriorityType priorityType, int priority, double threshold)
        {
            PriorityType = priorityType;
            Priority = priority;
            Threshold = threshold;
        }
        //public string TagName { get; set; }


    }
}
