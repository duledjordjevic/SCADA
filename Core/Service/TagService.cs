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

        public TagService() 
        {
            TagProccessing.LoadTags();
            TagProccessing.StartThreads();
            
        }

        public void AddTag(Tag tag)
        {
            InitNotifier();

            if (TagProccessing.AddTag(tag))
            {
                SendMessage($"New tag added successfuly.");
                SendMessage($"{tag}");
            }
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
            
            var removed = TagProccessing.RemoveTag(name);

            if (removed) {
                SendMessage("Tag removed successfuly.");
            } else
            {
                SendMessage("Error: Tag doesn`t exist!");
            }
        }


        public void SetOutput(double value)
        {
            throw new NotImplementedException();
        }

        public void ToggleScan(string tagName)
        {
            InitNotifier ();
            if(TagProccessing.ToggleScan(tagName))
            {
                SendMessage("Successfuly toggled tag!");
                return;
            }
            SendMessage("Error: tag not found");
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
