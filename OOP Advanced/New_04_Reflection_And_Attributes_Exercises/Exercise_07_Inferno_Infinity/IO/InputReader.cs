namespace Exercise_07_Inferno_Infinity.IO
{
    using System;
    using Contracts;

    public class InputReader : IReader
    {
        public string Read() => Console.ReadLine();
    }
}
