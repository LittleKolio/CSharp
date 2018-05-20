namespace BashSoft_OOP.Core.Commands
{
    using Abstract;
    using IO.Interfaces;
    using Repository.Interfaces;
    using System.IO;

    /// <summary>
    /// Initialize (fill) of the database through JSON file in current directory.
    /// </summary>
    /// <example>readjson {0_(string)courses/students} {1_(string)fileName}</example>

    public class ReadjsonCommand : Command
    {
        private const int argumentsNumber = 2;

        private IFilesystemManager filesystemManager;
        private IProcessJsonFormat processJsonFormat;

        public ReadjsonCommand(
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
