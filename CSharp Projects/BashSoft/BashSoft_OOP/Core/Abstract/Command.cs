namespace BashSoft_OOP.Core.Abstract
{
    using Interfaces;
    using StaticData;
    using System;

    public abstract class Command : IExecutable
    {
        private readonly int argumentsNumber;
        private string[] arguments;

        protected Command(string[] arguments, int argumentsNumber)
        {
            this.argumentsNumber = argumentsNumber;
            this.Arguments = arguments;
        }

        protected string[] Arguments
        {
            get { return this.arguments; }
            set
            {
                if (value.Length != this.argumentsNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format(
                        ExceptionMessages.params_InvalidNumber, argumentsNumber));
                }

                this.arguments = value;
            }
        }

        public abstract void Execute();
    }
}
