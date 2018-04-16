using System;

public class StartUp
{
    public static void Main()
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        IProviderFactory providerFactory = new ProviderFactory();
        IHarvesterFactory harvesterFactory = new HarvesterFactory();

        IProviderController providerController = new ProviderController(energyRepository, providerFactory);
        IHarvesterController harvesterContrller = new HarvesterController(energyRepository, harvesterFactory);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterContrller, providerController);

        Engine engine = new Engine(commandInterpreter);
        engine.Run();

        Console.WriteLine("ddddd");
    }
}