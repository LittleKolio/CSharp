namespace BashSoft_OOP.Core.Commands
{
    using BashSoft_OOP.Interface;

    public abstract class Command : IExecutable
    {
        protected Command(string[] arguments)
        {
            this.Arguments = arguments;
        }

        public string[] Arguments { get; }

        public abstract void Execute();
    }
}
