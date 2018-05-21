namespace BashSoft_OOP.Core.Commands
{
    using Abstract;
    using IO.Interfaces;

    /// <summary>
    /// Creates directory in the current by given name.
    /// </summary>
    /// <example>createdirectory {0_(string)directoryName}</example>

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
