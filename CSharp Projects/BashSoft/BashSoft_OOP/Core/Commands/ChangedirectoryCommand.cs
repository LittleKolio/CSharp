namespace BashSoft_OOP.Core.Commands
{
    using Abstract;
    using IO.Interfaces;

    /// <summary>
    /// Change directory by given relative path.
    /// If the path does not exist FilesystemManager throws argument exception.
    /// </summary>
    /// <example>changedirectory {0_(string)relativeDirectoryPath}</example>

    public class ChangedirectoryCommand : Command
    {
        private const int argumentsNumber = 1;

        private IFilesystemManager filesystemManager;

        public ChangedirectoryCommand(
            string[] arguments, 
            IFilesystemManager filesystemManager) 
            : base(arguments, argumentsNumber)
        {
            this.filesystemManager = filesystemManager;
        }

        public override void Execute()
        {
            string relativeDirectoryPath = base.Arguments[0];

            this.filesystemManager.ChangeDirectoryByRelativePath(relativeDirectoryPath);
        }
    }
}
