namespace Exercise_03_BarracksWars_A_New_Factory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class AppEntryPoint
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureService();

            //IRepository repository = new UnitRepository();
            //IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        public static IServiceProvider ConfigureService()
        {
            IServiceCollection collection = new ServiceCollection();
            collection.AddTransient<IUnitFactory, UnitFactory>();
            collection.AddSingleton<IRepository, UnitRepository>();

            return collection.BuildServiceProvider();
        }
    }
}
