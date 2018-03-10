public abstract class Driver
{
    public Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public string Name { get; private set; }
    public Car Car { get; private set; }

    public double TotalTime { get; set; }
    public double FuelConsumptionPerKm { get; set; }
    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

}