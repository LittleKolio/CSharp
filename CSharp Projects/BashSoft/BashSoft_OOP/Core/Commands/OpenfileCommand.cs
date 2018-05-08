using BashSoft_OOP.Interface;
using System;

namespace BashSoft_OOP.Core.Commands
{
    /// <summary>
    /// Opens a file with default program for windows.
    /// First we have to change current directory to location of the file.
    /// </summary>

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
