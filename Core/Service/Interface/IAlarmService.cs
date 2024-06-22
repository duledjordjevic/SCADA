using Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Core.Service
{
    [ServiceContract(CallbackContract = typeof(IPriorityCallback))]
    public interface IAlarmService
    {
        [OperationContract]
        void Subscribe();
    }
}
