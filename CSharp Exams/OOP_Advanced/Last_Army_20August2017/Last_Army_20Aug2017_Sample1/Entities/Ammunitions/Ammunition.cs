using System;

public abstract class Ammunition : IAmmunition
{
    protected Ammunition(double weight)
    {
        this.Weight = weight;
        this.WearLevel = weight * 100;
    }

    //public abstract string NameTest { get; }

    public string Name => this.GetType().Name;

    public double WearLevel { get; private set; }

    public double Weight { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}