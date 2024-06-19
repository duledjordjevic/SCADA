using CommonLibrary.Model;
using CommonLibrary.Model.Enum;
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

            List<Alarm> alarms = new List<Alarm>
            {
                new Alarm(AlarmPriorityType.LOW, 1, 4.0),
                new Alarm(AlarmPriorityType.HIGH, 2, 35.0)
            };

            AnalogInput analogInput = new AnalogInput(
                name: "TemperatureSensor",
                description: "Measures temperature",
                address: "1",
                isSyncTurned: true,
                syncTime: 3,
                lowLimit: -10.0,
                highLimit: 50.0,
                unit: "Celsius",
                alarms: alarms
            );


            TagProccessing.AddTag(analogInput);
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
            InitNotifier();
            TagProccessing.LoadTags();

            foreach (var tag in TagProccessing.analogInputs)
            {
                SendMessage(tag.ToString());
            }

            TagProccessing.RemoveTag("TemperatureSensor");

            foreach (var tag in TagProccessing.analogInputs)
            {
                SendMessage(tag.ToString());
            }
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
