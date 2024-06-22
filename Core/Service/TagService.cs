using CommonLibrary.Model;
using CommonLibrary.Model.Enum;
using Core.Util;
using System.Collections.Generic;
using System.ServiceModel;

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
                SendMessage($"New tag added successfully.");
                return;
            }
            SendMessage($"Error: Tag name already exists!");
        }

        public List<string> ListTags(TagType type)
        {
            return TagProccessing.GetAllTagNames(type);
        }

        public void RemoveTag(string name)
        {
            InitNotifier();

            var removed = TagProccessing.RemoveTag(name);

            if (removed)
            {
                SendMessage("Tag removed successfully.");
            }
            else
            {
                SendMessage("Error: Tag doesn`t exist!");
            }
        }


        public void SetOutput(string tagName, double value)
        {
            InitNotifier();
            if (TagProccessing.SetOutput(tagName, value, out string message))
            {
                SendMessage(message);
                return;
            }
            SendMessage(message);
        }

        public void ToggleScan(string tagName)
        {
            InitNotifier();
            if (TagProccessing.ToggleScan(tagName))
            {
                SendMessage("Successfully toggled tag.");
                return;
            }
            SendMessage("Error: Tag doesn`t exist!");
        }

        public void InitNotifier()
        {
            notifier = OperationContext.Current.GetCallbackChannel<ICallBack>().MessageArrived;
        }
        public void SendMessage(string message)
        {
            notifier?.Invoke(message);
        }

        public void GetOutput(string tagName)
        {
            InitNotifier();
            if (TagProccessing.GetOutput(tagName, out var value))
            {
                SendMessage($"{tagName}: {value}");
                return;
            }
            SendMessage("Error: Tag doesn`t exist!");
        }

        public List<OutputTag> GetAllOutputs()
        {
            InitNotifier();
            return TagProccessing.GetAllOutputs();
        }
    }
}
