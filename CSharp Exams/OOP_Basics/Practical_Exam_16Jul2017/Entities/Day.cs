public class Day
{
    public Day(double energyStored, double minedOre)
    {
        this.EnergyStored = energyStored;
        this.MinedOre = minedOre;
    }

    private double energyStored;
    private double minedOre;

    public double EnergyStored
    {
        get { return this.energyStored; }
        private set { this.energyStored = value; }
    }
    public double MinedOre
    {
        get { return this.minedOre; }
        private set { this.minedOre = value; }
    }

    public override string ToString()
    {
        return string.Format(
            Constants.TOSTRING_DAY,
            this.EnergyStored,
            this.MinedOre
            );
    }
}
