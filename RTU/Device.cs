using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTU
{
    public class Device
    {
        public string Address { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public int Rate { get; set; }

        public Device()
        {
            
        }
    }
}
