namespace EFCommandPatternExtended
{
    using System;

    public class CommandNotFound : Command
    {
        public CommandNotFound(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new CommandNotFound(data);
        }

        public override void Execute()
        {
            //var data = this.data;
            //imame dostap do poleto v Commands
            Console.WriteLine("Command not found!");
        }
    }
}
