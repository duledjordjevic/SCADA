using CommonLibrary.Model;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Core.Service
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IReportService
    {
        [OperationContract]
        List<ActivatedAlarm> GetAlarmsByPeriod(DateTime startTime, DateTime endTime);

        [OperationContract]
        List<ActivatedAlarm> GetAlarmsByPriority(int priority);

        [OperationContract]
        List<TagEntity> GetTagValuesByPeriod(DateTime startTime, DateTime endTime);

        [OperationContract]
        List<TagEntity> GetLastAITagValues();

        [OperationContract]
        List<TagEntity> GetLastDITagValues();

        [OperationContract]
        List<TagEntity> GetTagValuesById(int tagId);
    }
}
