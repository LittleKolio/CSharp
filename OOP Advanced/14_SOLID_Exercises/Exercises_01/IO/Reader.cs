namespace SOLID_Exercises.Exercises_01.IO
{
    using System;
    using SOLID_Exercises.Exercises_01.Interfaces;

    public class Reader : IReader
    {
        public string ConsoleReader() => Console.ReadLine();
    }
}
