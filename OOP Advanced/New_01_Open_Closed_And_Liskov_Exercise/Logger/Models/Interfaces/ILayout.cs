namespace Logger
{
    public interface ILayout
    {
        string CreateLogMessage(IError args);
    }
}