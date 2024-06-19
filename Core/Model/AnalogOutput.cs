using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class AnalogOutput : OutputTag
    {
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Unit {  get; set; }
    }
}
