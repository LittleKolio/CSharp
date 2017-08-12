namespace SOLID_Exercises.Exercises_01.Models.Layouts
{
    using System;
    using SOLID_Exercises.Exercises_01.Interfaces;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string FormatMessage(string dateTime, string messageType, string message)
        {
            StringBuilder sb = new StringBuilder();
            return sb.AppendLine("<log>")
                .AppendLine($"  <date>{dateTime}</date>")
                .AppendLine($"  <type>{messageType}</type>")
                .AppendLine($"  <message>{message}</message>")
                .AppendLine("</log>")
                .ToString();
        }
    }
}
