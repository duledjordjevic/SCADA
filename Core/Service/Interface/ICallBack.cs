using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICallBack
    {
        [OperationContract(IsOneWay = true)]
        void MessageArrived(string message);
    }
}
