using CommonLibrary.Model;
using Core.Model;
using ReportManager.ReportServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    public class ReportClientAdapter
    {
        private readonly ReportServiceClient ReportClient;
        public ReportClientAdapter(ReportServiceClient reportClient) 
        {
            ReportClient = reportClient;
        }
        public void GetTagValuesByPeriod(DateTime startTime, DateTime endTime)
        {
            foreach(var tagEntity in ReportClient.GetTagValuesByPeriod(startTime, endTime))
            {
                Console.WriteLine(tagEntity.ToString());
            }
        }
        public void GetTagValuesById(int tagId)
        {
            foreach (var tagEntity in ReportClient.GetTagValuesById(tagId))
            {
                Console.WriteLine(tagEntity.ToString());
            }
        }
        public void GetLastDITagValues()
        {
            foreach (var tagEntity in ReportClient.GetLastDITagValues())
            {
                Console.WriteLine(tagEntity.ToString());
            }
        }
        public void GetLastAITagValues()
        {
            foreach (var tagEntity in ReportClient.GetLastAITagValues())
            {
                Console.WriteLine(tagEntity.ToString());
            }
        }
        public void GetAlarmsByPeriod(DateTime startTime, DateTime endTime)
        {
            foreach (var activatedAlarm in ReportClient.GetAlarmsByPeriod(startTime, endTime))
            {
                Console.WriteLine(activatedAlarm.ToString());
            }
        }
        public void GetAlarmsByPriority(int priority)
        {
            foreach (var activatedAlarm in ReportClient.GetAlarmsByPriority(priority))
            {
                Console.WriteLine(activatedAlarm.ToString());
            }
        }
    }
}
