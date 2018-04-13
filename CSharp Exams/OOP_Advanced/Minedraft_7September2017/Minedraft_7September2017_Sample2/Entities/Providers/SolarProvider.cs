public class SolarProvider : Provider
{
    private const int extraDurability = 500;

    public SolarProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        base.Durability += extraDurability;
    }
}