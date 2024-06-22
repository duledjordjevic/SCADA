using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD
{
    public class SimulationDriver
    {
        public static bool TryGetValue(string address, out double value)
        {
            switch (address)
            {
                case "S":
                    value = Sine();
                    return true;
                case "C":
                    value = Cosine();
                    return true;
                case "R":
                    value = Ramp();
                    return true;
                default:
                    value = 0;
                    return false;
            }
        }

        private static double Sine()
        {
            return 100 * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI);
        }

        private static double Cosine()
        {
            return 100 * Math.Cos((double)DateTime.Now.Second / 60 * Math.PI);
        }

        private static double Ramp()
        {
            return 100 * DateTime.Now.Second / 60;
        }

    }
}
