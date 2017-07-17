using System;
using System.Text;

public abstract class Harvester
{
    public Harvester(string id, double oreOutput, double energyRequirement)
    : this(id, oreOutput)
    {
        this.EnergyRequirement = energyRequirement;
    }
    public Harvester(string id, double oreOutput)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
    }

    private string id;
    private double oreOutput;
    private double energyRequirement;

    public string Id
    {
        get { return this.id; }
        private set { this.id = value; }
    }

    public virtual double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(
                    Constants.EXEPTION_HARVESTER_ORE,
                    "OreOutput"
                    ));
            }
            this.oreOutput = value;
        }
    }

    public virtual double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < Constants.MIN_HARVESTER_ENERGY || 
                Constants.MAX_HARVESTER_ENERGY < value)
            {
                throw new ArgumentException(string.Format(
                    Constants.EXEPTION_HARVESTER_ENERGY,
                    "EnergyRequirement"
                    ));
            }
            this.energyRequirement = value;
        }
    }

    public void HalfMode()
    {
        this.EnergyRequirement = this.EnergyRequirement *
            Constants.MODIFIER_HALFMODE_ENERGY /
            Constants.MAXIMUM_PERCENTAGE;
        this.OreOutput = this.OreOutput *
            Constants.MODIFIER_HALFMODE_ORE /
            Constants.MAXIMUM_PERCENTAGE;
    }

    public void EnergyMode()
    {
        this.EnergyRequirement = Constants.MODIFIER_ENERGYMODE_ENERGY;
        this.OreOutput = Constants.MODIFIER_ENERGYMODE_ORE;
    }

    public override string ToString()
    {
        return string.Format(
            Constants.TOSTRING_HARVESTER,
            this.GetType().Name.Replace("Harvester", string.Empty),
            this.Id,
            this.OreOutput,
            this.EnergyRequirement
            );
    }
}
