using System.ServiceModel;

namespace Core.Service
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IUserService
    {
        [OperationContract]
        bool Register(string username, string password);

        [OperationContract]
        string Login(string username, string password);

        [OperationContract]
        bool Logout(string token);
    }
}
