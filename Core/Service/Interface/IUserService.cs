using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;

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
