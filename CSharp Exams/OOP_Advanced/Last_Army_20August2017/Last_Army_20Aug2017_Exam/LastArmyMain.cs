public class LastArmyMain
{
    static void Main()
    {
        IGameController gameController = new GameController();
        Engine engine = new Engine(gameController);
        engine.Run();
    }
}