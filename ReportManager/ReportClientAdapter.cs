using CommonLibrary.ConsoleTools;
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
        public void GetTagValuesByPeriod()
        {
            ConsoleReader.ReadStartAndEndDateTimes(out DateTime startTime, out DateTime endTime);

            foreach (var tagEntity in ReportClient.GetTagValuesByPeriod(startTime, endTime))
            {
                PrettyConsole.WriteLine(tagEntity.ToString());
            }
        }
        public void GetTagValuesByName()
        {
            var name = ReportConsoleReader.GetTagValuesByName();
            foreach (var tagEntity in ReportClient.GetTagValuesByName(name))
            {
                PrettyConsole.WriteLine(tagEntity.ToString());
            }
        }
        public void GetLastDITagValues()
        {
            foreach (var tagEntity in ReportClient.GetLastDITagValues())
            {
                PrettyConsole.WriteLine(tagEntity.ToString());
            }
        }
        public void GetLastAITagValues()
        {
            foreach (var tagEntity in ReportClient.GetLastAITagValues())
            {
                PrettyConsole.WriteLine(tagEntity.ToString());
            }
        }
        public void GetAlarmsByPeriod()
        {
            ConsoleReader.ReadStartAndEndDateTimes(out DateTime startTime, out DateTime endTime);

            foreach (var activatedAlarm in ReportClient.GetAlarmsByPeriod(startTime, endTime))
            {
                PrettyConsole.WriteLine(activatedAlarm.ToString());
            }
        }
        public void GetAlarmsByPriority()
        {
            var priority = ReportConsoleReader.GetAlarmsByPriority();
            foreach (var activatedAlarm in ReportClient.GetAlarmsByPriority(priority))
            {
                PrettyConsole.WriteLine(activatedAlarm.ToString());
            }
        }
    }
}
