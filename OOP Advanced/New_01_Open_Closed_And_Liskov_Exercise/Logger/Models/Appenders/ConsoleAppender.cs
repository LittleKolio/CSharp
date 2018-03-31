namespace Logger
{
    using System;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int Count { get; private set; }

        public void WriteLogMessage(IError error)
        {
            string msg = this.Layout.CreateLogMessage(error);
            Console.WriteLine(msg);
            this.Count++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;

            return string.Format(Constants.AppenderToString,
                appenderType, layoutType, this.Level, this.Count);
        }
    }
}
