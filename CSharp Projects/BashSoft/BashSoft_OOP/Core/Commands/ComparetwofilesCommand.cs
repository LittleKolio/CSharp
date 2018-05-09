namespace BashSoft_OOP.Core.Commands
{
    using Interface;
    using IO;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ComparetwofilesCommand : Command
    {
        private const int argumentsNumber = 2;

        private IFilesystemManager fileSystemManager;
        private ICompareFiles compareFiles;

        public ComparetwofilesCommand(
            string[] arguments,
            IFilesystemManager fileSystemManager,
            ICompareFiles compareFiles) 
            : base(arguments, argumentsNumber)
        {
            this.fileSystemManager = fileSystemManager;
            this.compareFiles = compareFiles;
        }

        public override void Execute()
        {
            string currentDirectory = this.fileSystemManager.CurrentDirectory;

            string fileOnePath = Path.Combine(currentDirectory, base.Arguments[0]);
            string fileTwoPath = Path.Combine(currentDirectory, base.Arguments[1]);

            this.compareFiles.CompareTwoFiles(fileOnePath, fileTwoPath);
        }
    }
}
