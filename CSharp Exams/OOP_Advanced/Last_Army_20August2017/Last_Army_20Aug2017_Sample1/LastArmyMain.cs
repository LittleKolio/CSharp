public class LastArmyMain
{
    public static void Main()
    {
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
            wearHouse);

        //Engine
        Engine engine = new Engine(gameController);
        engine.Run();
    }
}