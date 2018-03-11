
public class AggressiveDriver : Driver
{
    private const double multiplier = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car)
    {
        base.fuelConsumptionPerKm = 2.7;
    }

    public override double Speed => base.Speed * multiplier;
}