namespace BashSoft.Commands
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;

    public class CreateDirectorty : Command
    {
        private string folderName;

        public CreateDirectorty(string folderName)
        {
            this.folderName = folderName;
        }

        public override void Execute()
        {
            CustomPath.CreateDirectory(this.folderName);
        }
    }
}
