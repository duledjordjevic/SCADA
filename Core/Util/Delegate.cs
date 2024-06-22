namespace Core.Util
{
    public delegate void MessageArrivedDelegate(string message);
    public delegate void PriorityMessageArrivedDelegate(string message, int priority);
}
