using CommonLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    public interface IDriver
    {
        double GetValue(string address);
    }
}
