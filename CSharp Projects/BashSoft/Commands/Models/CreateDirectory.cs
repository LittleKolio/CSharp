namespace BashSoft.Commands
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Create folder in the current directory by given name.
    /// </summary>
    [Cmd(CmdEnum.mkdir)]
    public class CreateDirectory : ICmd
    {
        private string folderName;

        public CreateDirectory(string folderName)
        {
            this.FolderName = folderName;
        }

        public string FolderName
        {
            get { return this.folderName; }
            set { this.folderName = value; }
        }

        private string Path()
        {
            return CustomPath.CurrentPath + "\\" + this.FolderName;
        }

        public void Execute()
        {
            try
            {
                Directory.CreateDirectory(this.Path());
            }
            catch (ArgumentException)
            {
                OutputWriter.WriteExeption(
                    CustomMessages.NotAllowedCharacters);
            }
        }
    }
}
