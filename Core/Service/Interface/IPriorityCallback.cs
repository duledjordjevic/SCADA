using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Interface
{
    public interface IPriorityCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageArrived(string message, int priority);
    }
}
