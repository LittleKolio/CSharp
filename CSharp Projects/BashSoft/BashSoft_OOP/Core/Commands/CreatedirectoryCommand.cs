using BashSoft_OOP.Interface;

namespace BashSoft_OOP.Core.Commands
{
    /// <summary>
    /// Creates directory in the current by given name.
    /// First we have to change current directory to location where we want to create.
    /// </summary>
    /// <example>createdirectory {0_directoryName}</example>

    public class CreatedirectoryCommand : Command
    {
        private const int argumentsNumber = 1;

        private IFilesystemManager filesystemManager;

        public CreatedirectoryCommand(
            string[] arguments, 
            IFilesystemManager filesystemManager) 
            : base(arguments, argumentsNumber)
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
