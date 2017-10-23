namespace BashSoft.Commands
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;

    //[Command(CommandCode.mkdir)]
    [Cmd("mkdir")]
    public class CreateDirectorty : ICommand
    {
        public CreateDirectorty(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void Execute()
        {
            OutputWriter.WriteOneLineMessage("Command: mkdir - " + this.Name);
            //CustomPath.CreateDirectory(base.List[0]);
        }
    }
}
