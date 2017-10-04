namespace BashSoft.Core
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private Dictionary<string, ICommand>

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
