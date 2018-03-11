using System;

public abstract class Harvester
{
    public Harvester()
    {

    }

    public string Id { get; private set; }

    private double oreOutput;
    public double OreOutput
    {
        get { return this.oreOutput; }
        private set
        {
            if (value < 0)
            {
                throw new Exception();
            }
            this.oreOutput = value;
        }
    }

    private double energyRequirement;
    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        private set
        {
            if (value < 0 || value > 20000)
            {
                throw new Exception();
            }
            this.energyRequirement = value;
        }
    }

}