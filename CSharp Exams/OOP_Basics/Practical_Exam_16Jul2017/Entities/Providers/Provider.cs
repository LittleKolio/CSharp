using System;

public abstract class Provider
{
    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    private string id;
    private double energyOutput;

    public string Id
    {
        get { return this.id; }
        private set { this.id = value; }
    }
    public virtual double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < Constants.MIN_PROVIDER_ENERGY ||
                Constants.MAX_PROVIDER_ENERGY < value)
            {
                throw new ArgumentException(string.Format(
                    Constants.EXEPTION_PROVIDER_ENERGY,
                    "EnergyOutput"
                    ));
            }
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        return string.Format(
            Constants.TOSTRING_PROVIDER,
            this.GetType().Name.Replace("Provider", string.Empty),
            this.Id,
            this.EnergyOutput
            );
    }
}
