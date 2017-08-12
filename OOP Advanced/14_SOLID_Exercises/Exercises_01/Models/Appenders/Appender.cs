namespace SOLID_Exercises.Exercises_01.Models.Appenders
{
    using System;
    using Enums;
    using Interfaces;
    using System.Text;

    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public int Count { get; protected set; }

        public ILayout Layout { get; protected set; }

        public ReportType Type { get; set; }

        public abstract void Append(string dateTime, string messageType, string message);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return sb.AppendLine($"Appender type: {this.GetType().Name}, ")
                .Append($"Layout type: {this.Layout.GetType().Name}, ")
                .Append($"Report type: {this.Type.ToString().ToUpper()}, ")
                .Append($"Message appended: {this.Count}")
                .ToString();
        }
    }
}
