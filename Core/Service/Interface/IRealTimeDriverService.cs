using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Core.Service
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IRealTimeDriverService
    {
        [OperationContract]
        void RegisterRTU(string address);

        [OperationContract]
        void SendData(string address, double data);
    }
}
