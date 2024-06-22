using CommonLibrary.ConsoleTools;
using CommonLibrary.Model;
using DatabaseManager.TagServiceReference;

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

        public void SetOutput()
        {
            GetAllOutputs();
            var name = ConsoleReader.ReadString("tag name", "");
            var value = ConsoleReader.ReadDouble("value", "not double value");
            TagClient.SetOutput(name, value);
        }

        public void GetOutput()
        {
            var name = ConsoleReader.ReadString("tag name", "");
            TagClient.GetOutput(name);
        }

        public void GetAllOutputs()
        {
            foreach (var tag in TagClient.GetAllOutputs())
            {
                PrettyConsole.WriteLine($"{$"{tag.Name}:",-15} {tag.Value}");
            }
        }
    }
}
