namespace TeamBuilder.Clients
{
    using Commands;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Switcher
    {
        private Dictionary<string, Command> CmdList;

        public Switcher()
        {
            this.Initializer();
        }

        private void Initializer()
        {
            this.CmdList = new Dictionary<string, Command>
            {
                //{ "exit", new Command()}
            };
        }

        public Command GetCommand(string[] inputParam)
        {
            var key = inputParam[0];
            if (this.CmdList.ContainsKey(key))
            { return CmdList[key].CmdCreate(inputParam); }
            else
            {
                throw new NotSupportedException(
                  $"Command {key} not valid!");
            }
        }
    }
}
