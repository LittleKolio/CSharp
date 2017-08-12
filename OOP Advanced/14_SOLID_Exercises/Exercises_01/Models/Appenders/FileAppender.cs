
namespace SOLID_Exercises.Exercises_01.LibraryModels
{
    using System;
    using Enums;
    using SOLID_Exercises.Exercises_01.Interfaces;

    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; private set; }

        public LogFile File { get; set; }

        public ReportType Type { get; set; }

        public void Append(string dateTime, string messageType, string message)
        {
            this.File.Write(this.Layout.FormatMessage(dateTime, messageType, message));
        }
    }
}
