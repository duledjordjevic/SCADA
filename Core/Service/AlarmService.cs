using Core.Model;
using Core.Service.Interface;
using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Core.Service
{
    public class AlarmService : IBaseService, IPriorityService, IAlarmService
    {
        static PriorityMessageArrivedDelegate notifier;

        public void InitNotifier()
        {
            notifier = OperationContext.Current.GetCallbackChannel<IPriorityCallback>().MessageArrived;
        }

        public void SendMessage(string message, int priority)
        {
            notifier?.Invoke(message, priority);
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void Subscribe()
        {
            InitNotifier();
            AlarmProcessing.OnAlarmTriggered += HandleAlarm;
            SendMessage("Session initialized successfully.", 0);
        }

        private void HandleAlarm(ActivatedAlarm alarm)
        {
            SendMessage($"{alarm}", alarm.Alarm.Priority);
        }
    }
}
