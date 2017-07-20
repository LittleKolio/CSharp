public class Ferrari : ICar
{
    public string Driver { get; private set; }
    public Ferrari(string driver)
    {
        this.Driver = driver;
    }
    public string GasPedal()
    {
        return "Brakes!";
    }

    public string UseBrakes()
    {
        return "Zadu6avam sA!";
    }
}
