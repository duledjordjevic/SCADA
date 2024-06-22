using CommonLibrary.Model.Enum;
using System.Runtime.Serialization;

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

        [DataMember]
        public string TagName { get; set; }

        public Alarm() { }
        public Alarm(AlarmPriorityType priorityType, int priority, double threshold, string tagName)
        {
            PriorityType = priorityType;
            Priority = priority;
            Threshold = threshold;
            TagName = tagName;
        }

        public override string ToString()
        {
            return $"Alarm [PriorityType={PriorityType}, Priority={Priority}, Threshold={Threshold}]";
        }
    }
}
