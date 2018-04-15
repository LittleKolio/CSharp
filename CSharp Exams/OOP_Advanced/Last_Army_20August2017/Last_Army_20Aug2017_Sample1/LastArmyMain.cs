public class LastArmyMain
{
    public static void Main()
    {
        //Facttories
        MissionFactory missionFactory = new MissionFactory();
        SoldiersFactory soldiersFactory = new SoldiersFactory();
        AmmunitionFactory ammunitionFactory = new AmmunitionFactory();

        MissionController missionController = new MissionController(missionFactory);

        //Repositories
        Army army = new Army(soldiersFactory);
        WearHouse wearHouse = new WearHouse(ammunitionFactory);

        GameController gameController = new GameController(
            missionController,
            army, 
            wearHouse);

        Engine engine = new Engine(gameController);
        engine.Run();
    }
}