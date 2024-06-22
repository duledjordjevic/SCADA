using Core.Model;
using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;

namespace Core.Repository
{
    public class AlarmRepository
    {
        static readonly object dbLock = new object();

        public static void Add(ActivatedAlarm alarm)
        {
            lock (dbLock)
            {
                using (var db = new DatabaseContext())
                {
                    db.ActivatedAlarms.Add(alarm);
                    db.SaveChanges();
                }
            }
        }

        public static void RemoveAll(string tagName)
        {
            lock (dbLock)
            {
                using (var db = new DatabaseContext())
                {
                    db.ActivatedAlarms.RemoveRange(db.ActivatedAlarms.Where(alarm => alarm.Alarm.TagName == tagName));
                    db.SaveChanges();
                }
            }
        }

        public static List<ActivatedAlarm> GetAlarmsByPeriod(DateTime startTime, DateTime endTime)
        {
            lock (dbLock)
            {
                using (var db = new DatabaseContext())
                {
                    return db.ActivatedAlarms
                             .Where(a => a.TriggeredOn >= startTime && a.TriggeredOn <= endTime)
                             .OrderBy(a => a.Alarm.Priority)
                             .ThenBy(a => a.TriggeredOn)
                             .ToList();
                }
            }
        }

        public static List<ActivatedAlarm> GetAlarmsByPriority(int priority)
        {
            lock (dbLock)
            {
                using (var db = new DatabaseContext())
                {
                    return db.ActivatedAlarms
                             .Where(a => a.Alarm.Priority == priority)
                             .OrderBy(a => a.TriggeredOn)
                             .ToList();
                }
            }
        }
    }
}
