using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommonLibrary.Model;
using CommonLibrary.Model.Enum;

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
        void AddTag(Tag tag);

        [OperationContract]
        void RemoveTag(string name);

        [OperationContract]
        List<string> ListTags(TagType type);

    }
}
