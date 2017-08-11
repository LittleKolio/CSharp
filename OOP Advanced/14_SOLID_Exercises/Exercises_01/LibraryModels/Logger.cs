namespace SOLID_Exercises.Exercises_01.LibraryModels
{
    using System;
    using SOLID_Exercises.Exercises_01.Interfaces;

    public class Logger : ILogger
    {
        private IAppender[] appender;

        public Logger(params IAppender[] appender)
        {
            this.appender = appender;
        }

        private void Log(string dateTime, string messageType, string message)
        {
            foreach (IAppender item in this.appender)
            {
                item.Append(dateTime, messageType, message);
            }
        }

        public void Error(string dateTime, string message)
        {
            this.Log(dateTime, "Error", message);
        }

        public void Info(string dateTime, string message)
        {
            this.Log(dateTime, "Info", message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Log(dateTime, "Fatal", message);
        }

        public void Critical(string dateTime, string message)
        {
            this.Log(dateTime, "Critical", message);
        }

        public void Warning(string dateTime, string message)
        {
            throw new NotImplementedException();
        }
    }
}
