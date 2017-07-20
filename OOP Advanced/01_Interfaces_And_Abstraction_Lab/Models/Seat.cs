using System;

public class Seat : ICar
{
    public string Color { get; private set; }
    public string Model { get; private set; }

    public Seat(string model, string color)
    {
        this.Color = color;
        this.Model = model;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }
}