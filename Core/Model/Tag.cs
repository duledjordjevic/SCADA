using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public abstract class Tag
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
