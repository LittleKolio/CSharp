namespace SOLID_Exercises.Exercises_01.LibraryModels
{
    using System;
    using SOLID_Exercises.Exercises_01.Interfaces;
    using System.Linq;
    using Enums;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; private set; }
        public ReportType Type { get; set; }

        public void Append(string dateTime, string messageType, string message)
        {
            Console.WriteLine(this.Layout.FormatMessage(dateTime, messageType, message));
        }
    }
}
