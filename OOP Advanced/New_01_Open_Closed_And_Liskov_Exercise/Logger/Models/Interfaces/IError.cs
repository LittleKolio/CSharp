using System;

namespace Logger
{
    public interface IError
    {
        DateTime DateTime { get; }
        string Message { get; }
        ErrorLevel Level { get; }
    }
}
