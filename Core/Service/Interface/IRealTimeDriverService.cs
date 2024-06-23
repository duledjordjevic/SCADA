using System.ServiceModel;

namespace Core.Service
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IRealTimeDriverService
    {
        [OperationContract]
        bool RegisterRTU(string address);

        [OperationContract]
        void SendData(string address, string data, byte[] signature);
    }
}
