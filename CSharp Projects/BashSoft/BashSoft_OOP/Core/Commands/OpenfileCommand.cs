namespace BashSoft_OOP.Core.Commands
{
    using Abstract;
    using IO.Interfaces;

    /// <summary>
    /// Opens a file from current directory with default program for windows.
    /// </summary>
    /// <example>openfile {0_(string)fileName}</example>

    public class OpenfileCommand : Command
    {
        private const int argumentsNumber = 1;

        private IFilesystemManager filesystemManager;

        public OpenfileCommand(
            string[] arguments,
            IFilesystemManager filesystemManager) 
            : base(arguments, argumentsNumber)
        {
            this.filesystemManager = filesystemManager;
        }

        public override void Execute()
        {
            string fileName = base.Arguments[0];

            this.filesystemManager.OpenFile(fileName);
        }
    }
}
