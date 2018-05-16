namespace BashSoft_OOP.Core.Commands
{
    using Abstract;
    using IO.Interfaces;
    using StaticData;
    using System;

    /// <summary>
    /// Traversing current directory by given depth.
    /// We get current directory from FilesystemManager and only add dept as input.
    /// Traversing uses breadth-first.
    /// </summary>
    /// <example>traversedirectory {0_depth}</example>

    public class TraversedirectoryCommand : Command
    {
        private const int argumentsNumber = 1;

        private ITraverse traverse;
        private IFilesystemManager fileSystemManager;

        public TraversedirectoryCommand(
            string[] arguments,
            ITraverse traverse,
            IFilesystemManager fileSystemManager) 
            : base(arguments, argumentsNumber)
        {
            this.traverse = traverse;
            this.fileSystemManager = fileSystemManager;
        }

        public override void Execute()
        {
            string currentDirectory = this.fileSystemManager.CurrentDirectory;

            int depth;
            if (!int.TryParse(base.Arguments[0], out depth))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.params_InvalidParameter, base.Arguments[0]));
            }

            this.traverse.Traversing(currentDirectory, depth);
        }
    }
}
