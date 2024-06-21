using Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
