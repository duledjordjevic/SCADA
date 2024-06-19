using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public abstract class InputTag : Tag
    {
        public int SyncTime { get; set; }
        public bool IsSyncTurned { get; set; }
        public Driver Driver { get; set; }
    }
}
