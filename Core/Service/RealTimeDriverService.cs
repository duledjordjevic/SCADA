﻿using Core.Service.Interface;
using Core.Util;
using System.Collections.Generic;
using System.ServiceModel;

namespace Core.Service
{
    public class RealTimeDriverService : IBaseService, IAdvancedService, IRealTimeDriverService
    {
        public static Dictionary<string, double> RTUs = new Dictionary<string, double>();
        public static Dictionary<string, MessageArrivedDelegate> notifiers = new Dictionary<string, MessageArrivedDelegate>();
        static MessageArrivedDelegate tempNotifier;

        static readonly object RTULock = new object();


        public bool RegisterRTU(string address)
        {
            if (!RTUs.ContainsKey(address))
            {
                RTUs.Add(address, 0);
                InitNotifier(address);
                SendMessage(address, $"Registration successful: {address}");
                return true;
            }
            else
            {
                InitNotifier();
                SendMessage($"Registration failed!");
                return false;
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
                lock (RTUs)
                {
                    RTUs[address] = data;
                }
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

        public void InitNotifier()
        {
            tempNotifier = OperationContext.Current.GetCallbackChannel<ICallBack>().MessageArrived;
        }

        public void SendMessage(string message)
        {
            tempNotifier?.Invoke(message);
        }

        public static bool TryGetValue(string address, out double value)
        {
            lock (RTULock)
            {
                if (RTUs.ContainsKey(address))
                {
                    value = RTUs[address];
                    return true;
                }
                else
                {
                    value = 0;
                    return false;
                }
            }
        }
    }
}
