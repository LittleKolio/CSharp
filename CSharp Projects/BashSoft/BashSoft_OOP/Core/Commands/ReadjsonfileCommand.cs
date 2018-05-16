namespace BashSoft_OOP.Core.Commands
{
    using Abstract;
    using IO.Interfaces;
    using Repository.Interfaces;
    using System.IO;

    public class ReadjsonfileCommand : Command
    {
        private const int argumentsNumber = 2;

        private IFilesystemManager filesystemManager;
        private IProcessJsonFormat processJsonFormat;

        public ReadjsonfileCommand(
            string[] arguments,
            IFilesystemManager filesystemManager,
            IProcessJsonFormat processJsonFormat) 
            : base(arguments, argumentsNumber)
        {
            this.filesystemManager = filesystemManager;
            this.processJsonFormat = processJsonFormat;
        }

        public override void Execute()
        {
            string type = base.Arguments[0];
            string path = Path.Combine(this.filesystemManager.CurrentDirectory, base.Arguments[1]);

            switch (type)
            {
                case "students":
                    this.processJsonFormat.ReadStudentsFromFile(path);
                    break;

                case "courses":
                    this.processJsonFormat.ReadCoursesFromFile(path);
                    break;
            }
        }
    }
}
