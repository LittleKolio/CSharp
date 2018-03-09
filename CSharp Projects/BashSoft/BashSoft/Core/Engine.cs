namespace BashSoft.Core
{
    using BashSoft.IO;
    using Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private const string EndCommand = "quit";
        private CommandController controller;
        //private ICommand command;

        public Engine(CommandController controller)
        {
            this.controller = controller;
        }

        public void Run()
        {
            string input;
            while (!(input = InputReader.ConsoleReader())
                .Equals(EndCommand,StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new Exception(
                            CustomMessages.InputIsEmpty);
                    }

                    this.controller.Run(input).Execute();
                }
                catch (ArgumentException ex)
                {
                    OutputWriter.WriteExeption(ex.Message);
                }
                catch (FormatException ex)
                {
                    OutputWriter.WriteExeption(ex.Message);
                }
                catch (Exception ex)
                {
                    OutputWriter.WriteExeption(ex.Message);
                }
                //finally { }
            }
        }


    }
}
