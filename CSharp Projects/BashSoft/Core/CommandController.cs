namespace BashSoft.Core
{
    using Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandController
    {
        private Dictionary<string, Command> commandList;
        private List<string> list;

        public CommandController()
        {
            this.list = new List<string>();
            this.Initialize();
        }

        public Command Run(string input)
        {
            this.list = input.Split(new[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = this.list[0];

            if (!commandList.ContainsKey(command))
            {
                return new NotFound(this.list);
            }
            else
            {
                return this.commandList[command].Create(this.list);
            }
        }

        private void Initialize()
        {
            this.commandList = new Dictionary<string, Command>
            {
                { "mkdir", new CreateDirectorty(null) },
                { "test", new TestCommand(null) }
            };
        }
    }
}
