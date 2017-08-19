public class StartUp
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        HeroManager manager = new HeroManager();

        Engine engine = new Engine(reader, writer, manager);
        engine.Run();
    }
}