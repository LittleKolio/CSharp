using BashSoft_OOP.Interface;

namespace BashSoft_OOP.Core.Commands
{
    /// <summary>
    /// Creates directory in the current by given name.
    /// </summary>
    public class CreatedirectoryCommand : Command
    {
        private IFilesystemManager filesystemManager;

        public CreatedirectoryCommand(
            string[] arguments, 
            IFilesystemManager filesystemManager) 
            : base(arguments)
        {
            this.filesystemManager = filesystemManager;
        }

        public override void Execute()
        {
            string directoryName = base.Arguments[0];

            this.filesystemManager.CreateDirectory(directoryName);
        }
    }
}
