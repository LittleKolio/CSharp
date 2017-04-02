namespace TeamBuilder.Clients.Commands
{
    public abstract class Command
    {
        protected string[] cmdParam;
        public Command(string[] cmdParam)
        {
            this.cmdParam = cmdParam;
        }

        public abstract string CmdExecution();
        public abstract Command CmdCreate(string[] inputParam);
    }
}
