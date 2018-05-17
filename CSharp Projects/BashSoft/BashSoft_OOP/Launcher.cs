namespace BashSoft_OOP
{
    //
    using IO;
    using Core;
    using Repository;
    using Core.Interfaces;
    using IO.Interfaces;
    using Repository.Interfaces;

    //
    using System;
    using Microsoft.Extensions.DependencyInjection;


    public class Launcher
    {
        public static void Main()
        {
            #region Object Initialization
            ////IO
            //IWriter consoleWriter = new ConsoleWriter();
            //IReader consoleReader = new ConsoleReader();

            ////Repo
            //IStudentsRepository studentsRepository = new StudentsRepository(consoleWriter, consoleReader);

            //ICommandInterpreter commandInterpreter = new CommandInterpreter(studentsRepository);
            //IFilesystemManager filesystemManager = new FilesystemManager();

            //IEngine engine = new Engine(commandInterpreter, filesystemManager, consoleWriter, consoleReader);
            #endregion

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
            collection.AddSingleton<IRepository, CoursesRepository>();
            collection.AddSingleton<IFilesystemManager, FilesystemManager>();

            //Transient
            collection.AddTransient<ISorter, RepositorySorter>();
            collection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            collection.AddTransient<IEngine, Engine>();
            collection.AddTransient<ITraverse, TraversingDirectory>();
            collection.AddTransient<IFormat, FormatToPrint>();
            collection.AddTransient<ICompareFiles, CompareFiles>();
            collection.AddTransient<IProcessJsonFormat, ProcessJsonFormat>();
            collection.AddTransient<IProcessCustomFormat, ProcessCustomFormat>();

            return collection.BuildServiceProvider();
        }
    }
}
