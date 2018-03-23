namespace Logger
{
    using System;
    using System.IO;

    public class LoggFile : ILoggFile
    {
        private string fileName;

        public LoggFile(string fileName)
        {
            this.fileName = fileName;
            this.Size = 0;
        }

        public string filePath => Path.Combine(Directory.GetCurrentDirectory(), this.fileName);

        public int Size { get; private set; }

        public void WriteToFile(string msg)
        {
            File.AppendAllText(this.filePath, msg + Environment.NewLine);

            int msgSize = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                msgSize += msg[i];
            }
            this.Size += msgSize;
        }
    }
}