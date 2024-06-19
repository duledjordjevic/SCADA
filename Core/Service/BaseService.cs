using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public abstract class BaseService
    {
        // TODO: Move the definition of notifier here.

        protected abstract void InitNotifier();

        protected void SendMessage(MessageArrivedDelegate notifier, string message)
        {
            notifier?.Invoke(message);
        }
    }
}
