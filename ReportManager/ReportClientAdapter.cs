using CommonLibrary.ConsoleTools;
using ReportManager.ReportServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    public class ReportClientAdapter
    {
        private readonly ReportServiceClient ReportClient;
        private readonly string Title;
        public ReportClientAdapter(ReportServiceClient reportClient, string title)
        {
            ReportClient = reportClient;
            Title = title;
        }
        public void GetTagValuesByPeriod()
        { 
            ConsoleReader.ReadStartAndEndDateTimes(out DateTime startTime, out DateTime endTime);

            Console.Clear();
            PrettyConsole.Write(Title);
            Console.WriteLine();

            foreach (var tagEntity in ReportClient.GetTagValuesByPeriod(startTime, endTime))
            {
                PrettyConsole.WriteLine(tagEntity.ToString());
            }
        }
        public void GetTagValuesByName()
        {
            var name = ReportConsoleReader.GetTagValuesByName();

            Console.Clear();
            PrettyConsole.Write(Title);
            Console.WriteLine();

            foreach (var tagEntity in ReportClient.GetTagValuesByName(name))
            {
                PrettyConsole.WriteLine(tagEntity.ToString());
            }
        }
        public void GetLastDITagValues()
        {

            Console.Clear();
            PrettyConsole.Write(Title);
            Console.WriteLine();

            foreach (var tagEntity in ReportClient.GetLastDITagValues())
            {
                PrettyConsole.WriteLine(tagEntity.ToString());
            }
        }
        public void GetLastAITagValues()
        {

            Console.Clear();
            PrettyConsole.Write(Title);
            Console.WriteLine();

            foreach (var tagEntity in ReportClient.GetLastAITagValues())
            {
                PrettyConsole.WriteLine(tagEntity.ToString());
            }
        }
        public void GetAlarmsByPeriod()
        {
            ConsoleReader.ReadStartAndEndDateTimes(out DateTime startTime, out DateTime endTime);

            Console.Clear();
            PrettyConsole.Write(Title);
            Console.WriteLine();

            foreach (var activatedAlarm in ReportClient.GetAlarmsByPeriod(startTime, endTime))
            {
                PrettyConsole.WriteLine(activatedAlarm.ToString());
            }
        }
        public void GetAlarmsByPriority()
        {
            var priority = ReportConsoleReader.GetAlarmsByPriority();

            Console.Clear();
            PrettyConsole.Write(Title);
            Console.WriteLine();

            foreach (var activatedAlarm in ReportClient.GetAlarmsByPriority(priority))
            {
                PrettyConsole.WriteLine(activatedAlarm.ToString());
            }
        }
    }
}
