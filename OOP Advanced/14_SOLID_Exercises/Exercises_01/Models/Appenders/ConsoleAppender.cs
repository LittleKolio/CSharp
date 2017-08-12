namespace SOLID_Exercises.Exercises_01.Models.Appenders
{
    using System;
    using SOLID_Exercises.Exercises_01.Interfaces;
    using System.Linq;
    using Enums;
    using IO;

    public class ConsoleAppender : Appender
    {
        private IWriter writer;

        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
            this.writer = new Writer();
        }

        public override void Append(string dateTime, string messageType, string message)
        {
            base.Count++;
            this.writer.ConsoleWriter(
                this.Layout.FormatMessage(
                    dateTime, messageType, message)
                    );
        }
    }
}