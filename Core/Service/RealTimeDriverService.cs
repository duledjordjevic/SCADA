using Core.Service.Interface;
using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

namespace Core.Service
{
    public class RealTimeDriverService : IAdvancedService, IRealTimeDriverService
    {
        public static Dictionary<string, double> RTUs = new Dictionary<string, double>();
        public static Dictionary<string, MessageArrivedDelegate> notifiers = new Dictionary<string, MessageArrivedDelegate>();

        public void RegisterRTU(string address)
        {
            if (!RTUs.ContainsKey(address)) 
            {
                RTUs.Add(address, 0);
                InitNotifier(address);
                SendMessage(address, $"Registration successful: {address}");
            } else
            {
                SendMessage(address, $"Initialization failed!");
            }
        }

        public void SendData(string address, double data)
        {
            if (!RTUs.ContainsKey(address))
            {
                SendMessage(address, $"Data transfer failed!");
            }
            else
            {
                RTUs[address] = data;
                SendMessage(address, $"Recieved data: {data}");
            }
        }

        public void InitNotifier(string reciever)
        {
            notifiers.Add(reciever, OperationContext.Current.GetCallbackChannel<ICallBack>().MessageArrived);
        }

        public void SendMessage(string reciever, string message)
        {
            notifiers[reciever]?.Invoke(message);
        }
    }
}
