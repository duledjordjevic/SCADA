using Core.Service.Interface;
using System.ServiceModel;

namespace Core.Service
{
    [ServiceContract(CallbackContract = typeof(IPriorityCallback))]
    public interface IAlarmService
    {
        [OperationContract]
        void Subscribe();
    }
}
