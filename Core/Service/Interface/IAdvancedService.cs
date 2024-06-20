using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Interface
{
    public interface IAdvancedService
    {
        void InitNotifier(string reciever);

        void SendMessage(string reciever, string message);
    }
}
