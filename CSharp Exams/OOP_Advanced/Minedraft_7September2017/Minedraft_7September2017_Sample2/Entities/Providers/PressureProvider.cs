public class PressureProvider : Provider
{
    private const int extraDurability = 500;
    private const int EnergyOutputMultiplier = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        base.Durability += extraDurability;
        base.EnergyOutput *= EnergyOutputMultiplier;
    }
}
