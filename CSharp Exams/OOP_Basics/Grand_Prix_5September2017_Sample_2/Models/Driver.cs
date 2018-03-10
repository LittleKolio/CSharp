public abstract class Driver
{
    protected double fuelConsumptionPerKm;

    public string Name { get; set; }
    public double TotalTime { get; set; }
    public Car Car { get; set; }
    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

}