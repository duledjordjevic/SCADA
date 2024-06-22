using System.ServiceModel;

namespace Core.Service
{
    public interface ICallBack
    {
        [OperationContract(IsOneWay = true)]
        void MessageArrived(string message);
    }
}
