namespace Core.Service.Interface
{
    public interface IPriorityService
    {
        void SendMessage(string message, int priority);
    }
}
