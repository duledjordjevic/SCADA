using Core.Model;
using Core.Repository;
using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommonLibrary.Model;

namespace Core.Service
{
    public class ReportService : IBaseService, IReportService
    {
        static MessageArrivedDelegate notifier;

        public List<ActivatedAlarm> GetAlarmsByPeriod(DateTime startTime, DateTime endTime)
        {
            return AlarmRepository.GetAlarmsByPeriod(startTime, endTime);
        }

        public List<ActivatedAlarm> GetAlarmsByPriority(int priority)
        {
            return AlarmRepository.GetAlarmsByPriority(priority);
        }

        public List<TagEntity> GetLastAITagValues()
        {
            return TagRepository.GetLastAITagValues();
        }

        public List<TagEntity> GetLastDITagValues()
        {
            return TagRepository.GetLastDITagValues();
        }

        public List<TagEntity> GetTagValuesByName(string name)
        {
            return TagRepository.GetTagValuesByName(name);
        }

        public List<TagEntity> GetTagValuesByPeriod(DateTime startTime, DateTime endTime)
        {
            return TagRepository.GetTagValuesByPeriod(startTime, endTime);
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
