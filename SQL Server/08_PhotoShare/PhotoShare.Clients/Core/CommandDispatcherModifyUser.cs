namespace PhotoShare.Clients.Core
{
    using Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandDispatcherModifyUser
    {
        private Dictionary<string, Command> commands;
        public CommandDispatcherModifyUser()
        {
            this.commands = new Dictionary<string, Command>
            {
                { "Password", new ModifyUserPassword(null)},
                { "BornTown", new ModifyUserBornTown(null)},
                { "CurrentTown", new ModifyUserCurrentTown(null)}
            };
        }

        public Command DispatchCommand(string[] cmdParam)
        {
            //string[] cmdParam = { username, property, value }
            var cmdKey = cmdParam[1];
            var cmdArrayNotFound = cmdParam.Skip(1).ToArray();

            if (this.commands.ContainsKey(cmdKey))
            {
                return this.commands[cmdKey].Create(cmdParam);
            }
            else
            {
                return new CommandNotFound(cmdArrayNotFound);
            }
        }
    }
}
