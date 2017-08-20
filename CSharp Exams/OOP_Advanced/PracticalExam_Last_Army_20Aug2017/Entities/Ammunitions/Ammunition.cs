using System;

public abstract class Ammunition : IAmmunition
{
    public Ammunition(
        string name, 
        //double wearLevel, 
        double weight)
    {
        this.Name = name;
        //this.WearLevel = wearLevel;
        this.Weight = weight;
    }

    public string Name { get; private set; }

    public double WearLevel { get; private set; }

    public double Weight { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        throw new NotImplementedException();
    }
}