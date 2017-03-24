namespace EFCommandPatternExtended
{
    using System.Collections.Generic;

    public class CommandParser
    {
        private Dictionary<string, Command> commands;
        public CommandParser()
        {
            this.Initialize();
        }

        public Command Parse(string key, MyData data)
        {
            if (this.commands.ContainsKey(key))
            {
                return this.commands[key].Create(data);
            }
            else
            {
                return new CommandNotFound(null);
            }
        }

        private void Initialize()
        {
            this.commands = new Dictionary<string, Command>
            {
                { "incr", new IncreaseNumber(null) },
                { "pStr", new PrintString(null) },
                { "pNum", new PrintNumber(null) }
            };
        }
    }
}
