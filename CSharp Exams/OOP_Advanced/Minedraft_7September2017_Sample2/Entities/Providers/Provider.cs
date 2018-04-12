using System;

public class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const int durabilityLossPerDay = 100;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        //this.Durability = Math.Max(0, this.Durability - durabilityLossPerDay);

        this.Durability -= durabilityLossPerDay;
        if (this.Durability < 0)
        {
            throw new ArgumentOutOfRangeException(
                "Provider broke!");
        }
    }

    public void Repair(double val)
    {
        throw new System.NotImplementedException();
    }

    public double Produce() => this.EnergyOutput;
}