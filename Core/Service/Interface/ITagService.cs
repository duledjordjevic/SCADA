using CommonLibrary.Model;
using CommonLibrary.Model.Enum;
using System.Collections.Generic;
using System.ServiceModel;

namespace Core.Service
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface ITagService
    {
        [OperationContract]
        void SetOutput(string tagName, double value);

        [OperationContract]
        void GetOutput(string tagName);

        [OperationContract]
        List<OutputTag> GetAllOutputs();

        [OperationContract]
        void ToggleScan(string tagName);

        [OperationContract]
        void AddTag(Tag tag);

        [OperationContract]
        void RemoveTag(string name);

        [OperationContract]
        List<string> ListTags(TagType type);

    }
}
