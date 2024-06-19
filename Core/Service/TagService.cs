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

        public void AddTag()
        {
            InitNotifier();
            TagProccessing.LoadTags();
            foreach (var tag in TagProccessing.analogInputs)
            {
                SendMessage(tag.ToString());
            }
        }

        public void GetOutput(double value)
        {
            throw new NotImplementedException();
        }

        public void RemoveTag(double value)
        {
            throw new NotImplementedException();
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
