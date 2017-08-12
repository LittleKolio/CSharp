namespace SOLID_Exercises.Exercises_01.Models.Layouts
{
    using System;
    using SOLID_Exercises.Exercises_01.Interfaces;


    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string dateTime, string messageType, string message)
        {
            return $"{dateTime} - {messageType} - {message}";
        }
    }
}
