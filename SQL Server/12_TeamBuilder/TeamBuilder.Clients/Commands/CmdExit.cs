using System;

namespace TeamBuilder.Clients.Commands
{
    public class CmdExit
        : Command
    {
        public CmdExit(string[] cmdParam) 
            : base(cmdParam)
        {
        }

        public override Command CmdCreate(string[] inputParam)
        {
            return new CmdExit(inputParam);
        }

        public override string CmdExecution()
        {
            Environment.Exit(0);
            return "Bye";
        }
    }
}
