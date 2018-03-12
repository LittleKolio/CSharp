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

    public string Id { get; private set; }

    private double oreOutput;
    public virtual double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new Exception(string.Format(
                    "Harvester is not registered, because of it's {0}",
                    "OreOutput"));
            }
            this.oreOutput = value;
        }
    }

    private double energyRequirement;
    public virtual double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new Exception(string.Format(
                    "Harvester is not registered, because of it's {0}",
                    "EnergyRequirement"));
            }
            this.energyRequirement = value;
        }
    }


    public override string ToString()
    {
        string type = this.GetType().Name;

        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0} Harvester - {1}" + Environment.NewLine,
            type.Substring(0, type.Length - 9), this.Id)
            .AppendFormat("Ore Output: {0}" + Environment.NewLine, this.OreOutput)
            .AppendFormat("Energy Requirement: {0}" + Environment.NewLine, this.EnergyRequirement);

        return sb.ToString().TrimEnd();
    }
}