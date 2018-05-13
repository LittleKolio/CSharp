namespace BashSoft_OOP.Core.Commands
{
    using BashSoft_OOP.Interface;
    using BashSoft_OOP.Repository;
    using System.IO;

    public class ReadjsonfileCommand : Command
    {
        private const int argumentsNumber = 2;

        private JsonRepository jsonRepository;
        private IFilesystemManager filesystemManager;

        public ReadjsonfileCommand(
            string[] arguments,
            IFilesystemManager filesystemManager,
            IWriter consoleWriter) 
            : base(arguments, argumentsNumber)
        {
            this.jsonRepository = new JsonRepository(consoleWriter);
            this.filesystemManager = filesystemManager;
        }

        public override void Execute()
        {
            string type = base.Arguments[0];
            string path = Path.Combine(this.filesystemManager.CurrentDirectory, base.Arguments[1]);

            switch (type)
            {
                case "students":
                    this.jsonRepository.ReadStudents(path);
                    break;

                case "courses":
                    this.jsonRepository.ReadCourses(path);
                    break;
            }
        }
    }
}
