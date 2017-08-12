namespace SOLID_Exercises.Exercises_01.LibraryModels
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
