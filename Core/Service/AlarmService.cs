using Core.Model;
using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Core.Service
{
    public class AlarmService : IBaseService, IAlarmService
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
            AlarmProcessing.OnAlarmTriggered += HandleAlarm;
            SendMessage("Session initialized successfully.");
        }

        private void HandleAlarm(ActivatedAlarm alarm, double value)
        {
            SendMessage($"{alarm} - Value: {value}");
        }
    }
}
