using System;

public abstract class Ammunition : IAmmunition
{
    public Ammunition(string name)
    {
        this.Name = name;
        this.WearLevel = this.Weight * 100;
    }

    public string Name { get; private set; }

    public double WearLevel { get; private set; }

    public abstract double Weight { get; }

    public void DecreaseWearLevel(double wearAmount)
    {
        throw new NotImplementedException();
    }
}