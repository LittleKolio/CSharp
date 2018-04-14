namespace RecyclingStation.Interfaces
{
    public interface IWriter
    {
        void AppendMessage(string message);
        void ConsoleWrite();
    }
}
