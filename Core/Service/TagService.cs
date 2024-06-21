using CommonLibrary.Model;
using CommonLibrary.Model.Enum;
using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Core.Service
{
    public class TagService : IBaseService, ITagService
    {
        static MessageArrivedDelegate notifier;

        public void AddTag(Tag tag)
        {
            InitNotifier();
            TagProccessing.LoadTags();
            TagProccessing.AddTag(tag);

            SendMessage($"Succesfully added new tag");
            SendMessage($"{tag}");
        }

        public void GetOutput(double value)
        {
            throw new NotImplementedException();
        }

        public List<string> ListTags(TagType type) 
        {
            return TagProccessing.GetAllTagNames(type);
        }

        public void RemoveTag(string name)
        {
            InitNotifier();
            TagProccessing.LoadTags();
            
            foreach (var tag in TagProccessing.analogOutputs)
            {
                SendMessage(tag.ToString());
            }

            TagProccessing.RemoveTag(name);

            foreach (var tag in TagProccessing.analogOutputs)
            {
                SendMessage(tag.ToString());
            }
        }


        public void SetOutput(double value)
        {
            throw new NotImplementedException();
        }

        public void ToggleScan()
        {
            throw new NotImplementedException();
        }

        public void InitNotifier()
        {
            notifier = OperationContext.Current.GetCallbackChannel<ICallBack>().MessageArrived;
        }
        public void SendMessage(string message)
        {
            notifier?.Invoke(message);
        }
    }
}
