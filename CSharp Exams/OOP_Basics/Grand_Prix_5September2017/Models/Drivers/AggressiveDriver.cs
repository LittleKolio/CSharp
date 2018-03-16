
public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car)
        : base(name, 2.7, car)
    {
    }

    public override double Speed => base.Speed * 1.3;
}