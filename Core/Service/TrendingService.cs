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
            SendMessage($"{tag} - Value: {value}");
        }
    }
}
