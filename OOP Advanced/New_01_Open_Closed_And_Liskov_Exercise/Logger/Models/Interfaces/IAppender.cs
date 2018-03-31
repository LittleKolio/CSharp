namespace Logger
{
    public interface IAppender
    {
        void WriteLogMessage(IError error);
        ILayout Layout { get; }
        ErrorLevel Level { get; }
        int Count { get; }
    }
}
