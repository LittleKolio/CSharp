namespace BashSoft_OOP.Core
{
    using System;
    using Abstract;
    using IO.Interfaces;

    public class HelpCommand : Command
    {
        private const int argumentsNumber = 0;

        private IWriter consoleWriter;

        public HelpCommand(
            string[] arguments,
            IWriter consoleWriter) 
            : base(arguments, argumentsNumber)
        {
            this.consoleWriter = consoleWriter;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
