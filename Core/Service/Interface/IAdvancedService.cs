namespace Core.Service.Interface
{
    public interface IAdvancedService
    {
        void InitNotifier(string reciever);

        void SendMessage(string reciever, string message);
    }
}
