namespace TeamBuilder.Clients2.Commands
{
    using System;
    using TeamBuilder.Clients2.Utilities;

    public class CmdExit
    {
        public string Execute(string[] cmdParam)
        {
            Check.CheckLength(0, cmdParam);
            //Environment.Exit(0);
            return "Bye";
        }
    }
}
