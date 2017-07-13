public class Engine
{
    private bool running;
    private NationBuilder nationBuilder;

    public Engine()
    {
        this.running = true;
        this.nationBuilder = new NationBuilder();
    }

    public void Run()
    {
        while (this.running)
        {

        }
    }
}
