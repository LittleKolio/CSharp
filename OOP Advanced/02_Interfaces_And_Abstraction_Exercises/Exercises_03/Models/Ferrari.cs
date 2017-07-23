using System;

public class Ferrari : ICar
{
    public string Driver { get; private set; }

    public string Model { get; private set; }

    public Ferrari(string driver)
    {
        this.Driver = driver;
        this.Model = "488-Spider";
    }
    public string GasPedal()
    {
        return "Brakes!";
    }

    public string UseBrakes()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.GasPedal()}/{this.UseBrakes()}/{this.Driver}";
    }
}
