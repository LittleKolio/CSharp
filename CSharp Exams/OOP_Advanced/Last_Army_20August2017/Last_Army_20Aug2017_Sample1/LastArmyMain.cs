public class LastArmyMain
{
    public static void Main()
    {
        //IO
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        //Facttories
        IMissionFactory missionFactory = new MissionFactory();
        ISoldierFactory soldiersFactory = new SoldierFactory();
        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();


        //Repositories
        IArmy army = new Army();
        IWareHouse wearHouse = new WareHouse(ammunitionFactory);

        //Controllers
        IMissionController missionController = new MissionController(army, wearHouse);
        IGameController gameController = new GameController(
            missionController,
            soldiersFactory,
            missionFactory,
            army, 
            wearHouse,
            writer);

        //Engine
        Engine engine = new Engine(gameController, reader, writer);
        engine.Run();
    }
}