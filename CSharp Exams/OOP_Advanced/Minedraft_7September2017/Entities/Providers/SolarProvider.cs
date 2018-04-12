public class SolarProvider : Provider
{
    private const int extraDurability = 500;

    public SolarProvider(int id, double energyOutput, double energyRequirement)
        : base(id, energyOutput, energyRequirement)
    {
        base.Durability += extraDurability;
    }
}