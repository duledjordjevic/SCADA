using CommonLibrary.Model;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Repository
{
    public class TagRepository
    {
        static readonly object dbLock = new object();

        public static void Add(Tag tag, double value)
        {
            lock (dbLock)
            {
                using (var db = new DatabaseContext())
                {
                    db.TagValues.Add(new TagEntity
                    {
                        Type = tag.GetType().Name,
                        TagName = tag.Name,
                        Value = value,
                        Timestamp = DateTime.Now
                    });

                    db.SaveChanges();
                }
            }
        }

        public static List<TagEntity> GetTagValuesByPeriod(DateTime startTime, DateTime endTime)
        {
            lock (dbLock)
            {
                using (var db = new DatabaseContext())
                {
                    return db.TagValues
                             .Where(tv => tv.Timestamp >= startTime && tv.Timestamp <= endTime)
                             .OrderBy(tv => tv.Timestamp)
                             .ToList();
                }
            }
        }

        public static List<TagEntity> GetLastAITagValues()
        {
            lock (dbLock)
            {
                using (var db = new DatabaseContext())
                {
                    return db.TagValues
                             .Where(tv => tv.Type == "AnalogInput")
                             .GroupBy(tv => tv.TagName)
                             .Select(g => g.OrderByDescending(tv => tv.Timestamp).FirstOrDefault())
                             .OrderBy(tv => tv.Timestamp)
                             .ToList();
                }
            }
        }

        public static List<TagEntity> GetLastDITagValues()
        {
            lock (dbLock)
            {
                using (var db = new DatabaseContext())
                {
                    return db.TagValues
                             .Where(tv => tv.Type == "DigitalInput")
                             .GroupBy(tv => tv.TagName)
                             .Select(g => g.OrderByDescending(tv => tv.Timestamp).FirstOrDefault())
                             .OrderBy(tv => tv.Timestamp)
                             .ToList();
                }
            }
        }

        public static List<TagEntity> GetTagValuesByName(string name)
        {
            lock (dbLock)
            {
                using (var db = new DatabaseContext())
                {
                    return db.TagValues
                             .Where(tv => tv.TagName == name)
                             .OrderBy(tv => tv.Value)
                             .ToList();
                }
            }
        }

    }
}
