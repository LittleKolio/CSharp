namespace SOLID_Exercises.Exercises_01.Models.Appenders
{
    using System;
    using Enums;
    using SOLID_Exercises.Exercises_01.Interfaces;
    using IO;

    public class FileAppender : Appender
    {
        private IWriter writer;

        public FileAppender(ILayout layout)
            : base (layout)
        {
            this.writer = new Writer();
        }

        public LogFile File { get; set; }

        public override void Append(string dateTime, string messageType, string message)
        {
            this.writer.ConsoleWriter(
                this.Layout.FormatMessage(
                    dateTime, messageType, message)
                    );
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
