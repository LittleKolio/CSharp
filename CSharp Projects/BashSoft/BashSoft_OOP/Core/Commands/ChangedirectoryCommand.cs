using BashSoft_OOP.Interface;

namespace BashSoft_OOP.Core.Commands
{
    /// <summary>
    /// Change directory by given relative path.
    /// If the path does not exist throws argument exeption.
    /// </summary>
    public class ChangedirectoryCommand : Command
    {
        private IFilesystemManager filesystemManager;

        public ChangedirectoryCommand(
            string[] arguments, 
            IFilesystemManager filesystemManager) 
            : base(arguments)
        {
            this.filesystemManager = filesystemManager;
        }

        public override void Execute()
        {
            string directoryPath = base.Arguments[0];

            this.filesystemManager.ChangeDirectoryByRelativePath(directoryPath);
        }
    }
}
