namespace BashSoft_OOP.Core.Commands
{
    using BashSoft_OOP.Interface;
    using System;

    public abstract class Command : IExecutable
    {
        protected Command(string[] arguments, int argumentsNumber)
        {
            if (arguments.Length != argumentsNumber)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.params_InvalidNumber, argumentsNumber));
            }

            this.Arguments = arguments;
        }

        protected string[] Arguments { get; }

        public abstract void Execute();
    }
}
