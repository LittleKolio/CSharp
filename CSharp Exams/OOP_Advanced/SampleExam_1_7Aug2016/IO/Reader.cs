namespace RecyclingStation.IO
{
    using Interfaces;
    using System;

    public class Reader : IReader
    {
        public string ConsoleReadLine() => Console.ReadLine();
    }
}
