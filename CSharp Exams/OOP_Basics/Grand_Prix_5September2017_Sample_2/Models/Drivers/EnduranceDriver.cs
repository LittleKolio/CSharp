public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, Car car) 
        : base(name, car)
    {
        base.fuelConsumptionPerKm = 1.5;
    }
}