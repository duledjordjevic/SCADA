using System.ServiceModel;

namespace Core.Service.Interface
{
    public interface IPriorityCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageArrived(string message, int priority);
    }
}
