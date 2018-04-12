public class StartUp
{
    public static void Main()
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        IProviderController providerController = new ProviderController(energyRepository);
        IHarvesterController harvesterContrller = new HarvesterController(energyRepository);
        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterContrller, providerController);
        Engine engine = new Engine(commandInterpreter);
        engine.Run();
    }
}