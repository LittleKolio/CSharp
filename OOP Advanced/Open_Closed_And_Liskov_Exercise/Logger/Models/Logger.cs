using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Logger
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void ChoseAppender(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.WriteLogMessage(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Logger info");
            foreach (IAppender app in this.appenders)
            {
                sb.AppendLine(app.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}