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

            ////IO
            //IWriter consoleWriter = new ConsoleWriter();
            //IReader consoleReader = new ConsoleReader();

            ////Repo
            //IStudentsRepository studentsRepository = new StudentsRepository(consoleWriter, consoleReader);

            //ICommandInterpreter commandInterpreter = new CommandInterpreter(studentsRepository);
            //IFilesystemManager filesystemManager = new FilesystemManager();

            //IEngine engine = new Engine(commandInterpreter, filesystemManager, consoleWriter, consoleReader);

            IServiceProvider serviceProvider = ConfigureService();

            IEngine engine = serviceProvider.GetService<IEngine>();

            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            IServiceCollection collection = new ServiceCollection();

            //Singleton
            collection.AddSingleton<IReader, ConsoleReader>();
            collection.AddSingleton<IWriter, ConsoleWriter>();
            collection.AddSingleton<IRepository, StudentsRepository>();
            collection.AddSingleton<IFilesystemManager, FilesystemManager>();

            //Transient
            collection.AddTransient<ISorter, RepositorySorter>();
            collection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            collection.AddTransient<IEngine, Engine>();
            collection.AddTransient<ITraverse, TraversingDirectory>();
            collection.AddTransient<IFormat, FormatToPrint>();
            collection.AddTransient<ICompareFiles, CompareFiles>();

            return collection.BuildServiceProvider();
        }
    }
}
