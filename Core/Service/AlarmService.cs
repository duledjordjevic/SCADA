using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Core.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlarmService" in both code and config file together.
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
            throw new NotImplementedException();
        }
    }
}
