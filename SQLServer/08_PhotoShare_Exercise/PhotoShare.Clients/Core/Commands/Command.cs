namespace PhotoShare.Clients.Core.Commands
{
    using System;
    using System.Collections.Generic;

    public abstract class Command
    {
        protected string[] cmdParam;
        public Command(string[] cmdParam)
        {
            this.cmdParam = cmdParam;
        }
        public abstract string Execute();
        public abstract Command Create(string[] cmdParam);
    }
}
