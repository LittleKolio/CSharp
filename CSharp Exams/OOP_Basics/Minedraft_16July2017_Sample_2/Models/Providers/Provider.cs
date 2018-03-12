using System;
using System.Text;

public abstract class Provider
{
    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id { get; private set; }

    private double energyOutput;
    public virtual double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new Exception();
            }
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        string type = this.GetType().Name;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0} Provider - {1}" + Environment.NewLine,
            type.Substring(0, type.Length - 8), this.Id)
            .AppendFormat("Energy Output: {0}" + Environment.NewLine, this.EnergyOutput);

        return sb.ToString().TrimEnd();
    }
}