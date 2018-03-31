using System.Collections.ObjectModel;

namespace Logger
{
    public interface ILogger
    {
        void ChoseAppender(IError error);
    }
}
