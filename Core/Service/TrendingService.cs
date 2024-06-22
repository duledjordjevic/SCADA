using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;
using CommonLibrary.Model;
using Core.Service.Interface;
using Core.Util;

namespace Core.Service
{
    public class TrendingService : IBaseService , ITrendingService
    {
        static MessageArrivedDelegate notifier;
        public void InitNotifier()
        {
            notifier = OperationContext.Current.GetCallbackChannel<ICallBack>().MessageArrived;
        }

        public void SendMessage(string message)
        {
            notifier?.Invoke(message);
        }

        public void Subscribe()
        {
            InitNotifier();
            TagProccessing.OnTagValueChanged += HandleTagValueChanged;
            SendMessage("Session initialized successfully.");
        }

        private void HandleTagValueChanged(InputTag tag, double value)
        {
            if (tag is AnalogInput analog) 
            {
                SendMessage($"{$"{analog.Name}:",-15} {Math.Round(value, 3),-10} {analog.Unit,-10} [{DateTime.Now}]");
            }
            else if (tag is DigitalInput digital) 
            {
                SendMessage($"{$"{digital.Name}:",-15} {value,-21} [{DateTime.Now}]");
            }
        }
    }
}
