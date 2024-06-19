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
        void Login(string username, string password);

        [OperationContract]
        void Register(string username, string password);
    }
}
