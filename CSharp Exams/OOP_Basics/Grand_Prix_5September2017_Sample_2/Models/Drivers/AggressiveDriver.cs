
//This type of drivers have FuelConsumptionPerKm equal to 2.7 liters.
//Also aggressive driver’s Speed is multiplied by 1.3.
public class AggressiveDriver : Driver
{
    private const double multiplier = 1.3;
    public override double Speed => base.Speed * multiplier;
}