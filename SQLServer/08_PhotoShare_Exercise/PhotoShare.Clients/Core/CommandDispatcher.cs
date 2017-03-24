namespace PhotoShare.Clients.Core
{
    using Commands;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class CommandDispatcher
    {
        private Dictionary<string, Command> commands;
        public CommandDispatcher()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.commands = new Dictionary<string, Command>
            {
                {"Exit", new ExitCommand(null)},
                {"RegisterUser", new RegisterUserCommand(null)},
                {"AddTown", new AddTownCommand(null)},
                {"ModifyUser", new ModifyUserCommand(null)},
                {"DeleteUser", new DeleteUser(null)},
                {"AddTag", new AddTagCommand(null)}

            };
        }

        public Command DispatchCommand(string[] cmdParam)
        {
            var cmdKey = cmdParam[0];
            var cmdParamNext = cmdParam.Skip(1).ToArray();

            if (this.commands.ContainsKey(cmdKey))
            { 
                return this.commands[cmdKey].Create(cmdParamNext);
            }
            else
            {
                return new CommandNotFound(cmdParam);
            }
        }
    }
}
