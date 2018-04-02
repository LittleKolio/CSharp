namespace Exercise_03_BarracksWars_A_New_Factory.Core.Commands
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get; private set; }

        public abstract string Execute();
    }
}
