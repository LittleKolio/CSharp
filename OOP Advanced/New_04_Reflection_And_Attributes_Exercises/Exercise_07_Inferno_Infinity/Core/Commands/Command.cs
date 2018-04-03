namespace Exercise_07_Inferno_Infinity.Core.Commands
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get; private set; }

        public abstract void Execute();
    }
}
