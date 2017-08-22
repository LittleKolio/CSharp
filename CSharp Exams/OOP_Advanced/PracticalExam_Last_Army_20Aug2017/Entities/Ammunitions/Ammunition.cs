using System;

public abstract class Ammunition : IAmmunition
{
    public Ammunition(
        string name, 
        double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = weight * 100;
    }

    public string Name { get; private set; }

    public double WearLevel { get; private set; }

    public double Weight { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        throw new NotImplementedException();
    }
}