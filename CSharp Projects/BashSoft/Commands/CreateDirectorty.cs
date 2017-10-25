namespace BashSoft.Commands
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;

    [Cmd(CmdEnum.mkdir)]
    public class CreateDirectorty : ICmd
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
