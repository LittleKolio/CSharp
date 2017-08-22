public class LastArmyMain
{
    static void Main()
    {
        GameController gameController = new GameController();
        Engine engine = new Engine(gameController);
        engine.Run();


    }
}