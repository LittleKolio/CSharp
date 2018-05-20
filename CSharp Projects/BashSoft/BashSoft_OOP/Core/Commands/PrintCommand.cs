namespace BashSoft_OOP.Core.Commands
{
    using System;
    using BashSoft_OOP.Core.Abstract;
    using Repository.Interfaces;
    using IO.Interfaces;

    /// <summary>
    /// Prints all courses who are in database.
    /// </summary>
    /// <example>print</example>

    public class PrintCommand : Command
    {
        private const int argumentsNumber = 0;

        private IRepository repository;
        private IWriter consoleWriter;

        public PrintCommand(
            string[] arguments,
            IRepository repository,
            IWriter consoleWriter) 
            : base(arguments, argumentsNumber)
        {
            this.repository = repository;
            this.consoleWriter = consoleWriter;
        }

        public override void Execute()
        {
            this.consoleWriter.WriteOneLineMessage(this.repository.ToString());
        }
    }
}
