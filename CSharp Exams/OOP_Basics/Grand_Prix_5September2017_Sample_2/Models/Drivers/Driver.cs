public abstract class Driver
{
    protected double fuelConsumptionPerKm;
    public string failureReason;

    public Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.failureReason = string.Empty;
    }

    public string Name { get; private set; }
    public Car Car { get; set; }
    public double TotalTime { get; set; }
    public virtual double Speed 
        => ((double)this.Car.Horsepower + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void IncreaseTotalTime(int trackLength)
    {
        this.TotalTime += (60 / ((double)trackLength / this.Speed));
    }

    public void DecreaseFuelAmount(int trackLength)
    {
        this.Car.FuelAmount -= (trackLength * this.fuelConsumptionPerKm);
    }
}