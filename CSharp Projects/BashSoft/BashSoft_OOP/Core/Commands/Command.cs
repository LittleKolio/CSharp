namespace BashSoft_OOP.Core.Commands
{
    using BashSoft_OOP.Interface;

    public abstract class Command : IExecutable
    {
        private string[] arguments;

        public Command(string[] arguments)
        {
            this.arguments = arguments;
        }

        public abstract void Execute();
    }
}
