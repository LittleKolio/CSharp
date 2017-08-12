namespace SOLID_Exercises.Exercises_01.IO
{
    using System;
    using SOLID_Exercises.Exercises_01.Interfaces;

    public class Writer : IWriter
    {
        public void ConsoleWriter(string result) => Console.WriteLine(result);
    }
}
