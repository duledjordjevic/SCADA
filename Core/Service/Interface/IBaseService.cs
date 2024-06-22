namespace Core.Service
{
    public interface IBaseService
    {
        void InitNotifier();

        void SendMessage(string message);
    }
}
