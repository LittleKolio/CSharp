namespace SOLID_Exercises.Exercises_01.Models
{
    using System;
    using Interfaces;
    using Enums;
    using System.Text;

    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        private void Log(string dateTime, string messageType, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                ReportType currentType = (ReportType)Enum
                    .Parse(typeof(ReportType), messageType);

                if (appender.Type <= currentType)
                {
                    appender.Append(dateTime, messageType.ToUpper(), message);
                }
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
            this.Log(dateTime, "Warning", message);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IAppender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }
            return sb.ToString();
        }
    }
}
