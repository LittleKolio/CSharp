public class LastArmyMain
{
    public static void Main()
    {
        Army army = new Army();
        WearHouse wearHouse = new WearHouse();
        SoldiersFactory soldiersFactory = new SoldiersFactory();
        AmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        MissionController missionController = new MissionController();

        GameController gameController = new GameController(
            missionController,
            soldiersFactory,
            ammunitionFactory,
            army, 
            wearHouse);

        Engine engine = new Engine(gameController);
        engine.Run();
    }
}