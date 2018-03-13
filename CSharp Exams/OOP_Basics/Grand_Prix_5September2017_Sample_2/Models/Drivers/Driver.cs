public abstract class Driver
{
    public string failureReason;

    public Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.failureReason = string.Empty;
    }

    public string Name { get; private set; }
    public Car Car { get; protected set; }
    public double TotalTime { get; set; }
    public double FuelConsumptionPerKm { get; protected set; }

    public virtual double Speed => this.Car.Speed;

    public void IncreaseTotalTime(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    public void DecreaseFuelAmount(int trackLength)
    {
        this.Car.FuelAmount -= trackLength * this.FuelConsumptionPerKm;
    }
}