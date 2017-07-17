public class SonicHarvester : Harvester
{
    public SonicHarvester(
        string id, 
        double oreOutput, 
        double energyRequirement, 
        int sonicFactor
        ) 
        : base(
            id, 
            oreOutput)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement = energyRequirement;
    }

    private int sonicFactor;

    public int SonicFactor
    {
        get { return this.sonicFactor; }
        private set { this.sonicFactor = value; }
    }

    public override double EnergyRequirement
    {
        get { return base.EnergyRequirement; }
        protected set
        {
            base.EnergyRequirement = value / this.SonicFactor;
        }
    }


}
