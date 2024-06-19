using Core.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Alarm
    {
        public AlarmPriorityType PriorityType { get; set; }
        public int Priority { get; set; }
        public double Threshold { get; set; }
        //public string TagName { get; set; }
    }
}
