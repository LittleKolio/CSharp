namespace PhotoShare.Clients.Core.Commands
{
    using System;

    public class ExitCommand : Command
    {
        public ExitCommand(string[] cmdParam) : base(cmdParam)
        {
        }

        public override Command Create(string[] cmdParam)
        {
            return new ExitCommand(cmdParam);
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return "Bye-bye!";
        }
    }
}
