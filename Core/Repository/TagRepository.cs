using CommonLibrary.Model;
using Core.Model;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    db.TagValues.Add( new TagEntity {
                        Type = tag.GetType().Name,
                        TagName = tag.Name,
                        Value = value,
                        Timestamp = DateTime.Now
                    });

                    db.SaveChanges();
                }
            }
        }

    }
}
