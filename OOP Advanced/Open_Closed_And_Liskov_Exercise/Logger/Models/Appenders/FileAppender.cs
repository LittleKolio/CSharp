namespace Logger
{
    public class FileAppender : IAppender
    {
        private ILoggFile loggFile;

        public FileAppender(ILayout layout, ErrorLevel level, ILoggFile loggFile)
        {
            this.Layout = layout;
            this.Level = level;
            this.loggFile = loggFile;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int Count { get; private set; }

        public void WriteLogMessage(IError error)
        {
            string msg = this.Layout.CreateLogMessage(error);
            this.loggFile.WriteToFile(msg);
            this.Count++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;

            return string.Format(Constants.LogFileToString,
                appenderType, layoutType, this.Level, this.Count, this.loggFile.Size);
        }
    }
}
