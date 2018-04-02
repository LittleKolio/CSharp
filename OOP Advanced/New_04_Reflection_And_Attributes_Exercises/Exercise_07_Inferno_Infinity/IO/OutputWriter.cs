namespace Exercise_07_Inferno_Infinity.IO
{
    using System;
    using Contracts;

    public class OutputWriter : IWriter
    {
        public void Write(string message) => Console.WriteLine(message);
    }
}
