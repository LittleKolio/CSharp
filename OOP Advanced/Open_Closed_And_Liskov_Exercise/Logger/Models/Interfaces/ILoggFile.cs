namespace Logger
{
    public interface ILoggFile
    {
        string filePath { get; }
        int Size { get; }
        void WriteToFile(string msg);
    }
}
