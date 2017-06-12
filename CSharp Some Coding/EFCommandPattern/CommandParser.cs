namespace EFCommandPattern
{
    using System.Collections.Generic;

    public class CommandParser
    {
        private Dictionary<string, Command> commands;
        public CommandParser()
        {
            this.Initialize();
        }

        public Command Parse(string key)
        {
            if (this.commands.ContainsKey(key))
            {
                return this.commands[key];
            }
            else
            {
                return new CommandNotFound();
            }
        }

        private void Initialize()
        {
            this.commands = new Dictionary<string, Command>
            {
                { "greet", new GreetingCommand() },
                //{ "greet", new GreetingCommand() }
            };
        }
    }
}
