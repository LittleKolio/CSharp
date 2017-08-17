namespace RecyclingStation.IO
{
    using Interfaces;
    using System;
    using System.Text;

    public class Writer : IWriter
    {
        private StringBuilder output;

        public Writer()
            : this (new StringBuilder())
        {
        }

        public Writer(StringBuilder output)
        {
            this.output = output;
        }
        public void AppendMessage(string message) => this.output.AppendLine(message);
        public void ConsoleWrite() => Console.WriteLine(this.output);
    }
}
