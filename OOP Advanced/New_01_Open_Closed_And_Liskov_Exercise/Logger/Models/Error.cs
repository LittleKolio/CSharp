using System;

namespace Logger
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, ErrorLevel level)
        {
            this.Level = level;
            this.Message = message;
            this.DateTime = dateTime;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }
    }
}
