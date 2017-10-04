namespace BashSoft.Core
{
    using Commands;
    using System;
    using System.Collections.Generic;

    public class CommandController
    {
        private Dictionary<string, Command> commandList;

        public CommandController(List<string> listParams)
        {
            this.Initialize(listParams);
        }

        private void Initialize(List<string> listParams)
        {
            this.commandList = new Dictionary<string, Command>
            {
                { "mkdir", new CreateDirectorty(listParams[0]) }
            };
        }
    }
}
