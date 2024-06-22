using System.ServiceModel;

namespace Core.Service.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITrendingService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface ITrendingService
    {
        [OperationContract]
        void Subscribe();
    }
}
