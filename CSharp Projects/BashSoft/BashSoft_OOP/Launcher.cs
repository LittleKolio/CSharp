namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using BashSoft_OOP.IO;
    using BashSoft_OOP.Core;
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public class Launcher
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureService();

            //IO
            IWriter consoleWriter = new ConsoleWriter();
            IReader consoleReader = new ConsoleReader();

            //Repo
            IStudentsRepository studentsRepository = new StudentsRepository(
                consoleWriter, consoleReader);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(studentsRepository);
            IFilesystemManager filesystemManager = new FilesystemManager();

            IEngine engine = new Engine(
                commandInterpreter, filesystemManager, consoleWriter, consoleReader);

            //engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            IServiceCollection service = new ServiceCollection();

            service.
        }
    }
}
