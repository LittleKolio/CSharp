namespace BashSoft.Commands
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;

    public class CreateDirectorty : Command
    {
        public CreateDirectorty(List<string> list) : base(list)
        {
        }

        public override Command Create(List<string> list)
        {
            return new CreateDirectorty(list);
        }

        public override void Execute()
        {
            OutputWriter.WriteOneLineMessage("Command: mkdir - " + base.list[1]);
            //CustomPath.CreateDirectory(base.List[0]);
        }
    }
}
