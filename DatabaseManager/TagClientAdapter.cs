using DatabaseManager.TagServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.Model;
using CommonLibrary.ConsoleTools;

namespace DatabaseManager
{
    public class TagClientAdapter
    {
        private readonly TagServiceClient TagClient;

        public TagClientAdapter(TagServiceClient tagClient)
        {
            TagClient = tagClient;
        }

        public void AddTag(Tag tag)
        {
            TagClient.AddTag(tag);
        }

        public void RemoveTag()
        {
            var name = ConsoleReader.ReadString("tag name", "");
            TagClient.RemoveTag(name);
        }

        public void ToggleScan()
        {
            var name = ConsoleReader.ReadString("tag name", "");
            TagClient.ToggleScan(name);
        }
    }
}
