using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Core.Service
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface ITagService
    {
        [OperationContract]
        void SetOutput(double value);

        [OperationContract]
        void GetOutput(double value);

        [OperationContract]
        void ToggleScan();

        [OperationContract]
        void AddTag();

        [OperationContract]
        void RemoveTag();

    }
}
