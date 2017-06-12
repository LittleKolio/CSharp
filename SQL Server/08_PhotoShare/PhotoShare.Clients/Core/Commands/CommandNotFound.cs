namespace PhotoShare.Clients.Core.Commands
{
    using System;

    public class CommandNotFound : Command
    {
        public CommandNotFound(string[] cmdParam) : base(cmdParam)
        {
        }

        public override Command Create(string[] cmdParam)
        {
            return new CommandNotFound(cmdParam);
        }

        public override string Execute()
        {
            var cmd = this.cmdParam[0];

            throw new InvalidOperationException(
                $"Command {cmd} not valid!");
        }
    }
}
