using System;

namespace TeamBuilder.Clients.Commands
{
    class CmdNotFound
        : Command
    {
        public CmdNotFound(string[] cmdParam) 
            : base(cmdParam)
        {
        }

        public override Command CmdCreate(string[] inputParam)
        {
            return new CmdNotFound(inputParam);
        }

        public override string CmdExecution()
        {
            throw new NotSupportedException(
                $"Command {this.cmdParam[0]} not valid!");
        }
    }
}
