namespace FestivalManager.Core.IO
{
    using System;
    using FestivalManager.Core.IO.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(string contents)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string contents) => Console.WriteLine(contents);
    }
}
