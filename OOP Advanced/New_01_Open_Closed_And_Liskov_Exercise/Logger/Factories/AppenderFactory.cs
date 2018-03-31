using System;

namespace Logger
{
    public class AppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ErrorLevel level)
        {
            switch (type)
            {
                case "ConsoleAppender": return new ConsoleAppender(layout, level);
                case "FileAppender":
                    {
                        ILoggFile loggFile = new LoggFile("LogTest.txt");
                        return new FileAppender(layout, level, loggFile);
                    }
                default: throw new ArgumentException("Invalide Appender Type!");
            }
        }
    }
}