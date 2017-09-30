namespace BashSoft.Core
{
    using BashSoft.IO;
    using System;

    public class Engine
    {
        private const string EndCommand = "quit";
        public void Run()
        {
            string input;
            while ((input = InputReader.ConsoleReader())
                .Equals(
                    EndCommand, 
                    StringComparison.InvariantCultureIgnoreCase)
                    )
            {
                OutputWriter.WriteOneLineMessage("Success!");
            }
        }
    }
}
