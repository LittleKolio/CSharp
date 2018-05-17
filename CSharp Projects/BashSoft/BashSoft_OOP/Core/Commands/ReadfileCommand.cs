namespace BashSoft_OOP.Core.Commands
{
    using Abstract;
    using IO.Interfaces;
    using Repository.Interfaces;
    using System.IO;

    /// <summary>
    /// Initialize (fill) the database from a file by given filename.
    /// First we have to change current directory to file directory.
    /// </summary>
    /// <example>readfile {0_fileName}</example>

    public class ReadfileCommand : Command
    {
        private const int argumentsNumber = 1;

        private IProcessCustomFormat processCustomformat;
        private IFilesystemManager filesystemManager;

        public ReadfileCommand(
            string[] arguments,
            IProcessCustomFormat processCustomformat, 
            IFilesystemManager filesystemManager) 
            : base(arguments, argumentsNumber)
        {
            this.processCustomformat = processCustomformat;
            this.filesystemManager = filesystemManager;
        }

        public override void Execute()
        {
            string path = Path.Combine(this.filesystemManager.CurrentDirectory, base.Arguments[0]);

            this.processCustomformat.ReadDataFile(path);
        }
    }
}
