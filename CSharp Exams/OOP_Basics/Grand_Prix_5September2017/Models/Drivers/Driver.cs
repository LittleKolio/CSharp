public abstract class Driver
{
    protected Driver(string name, double fuelConsumptionPerKm, Car car)
    {
        this.Name = name;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.Car = car;
    }

    private double totalTime;

    public double FuelConsumptionPerKm { get; }
    public Car Car { get; }
    public double TotalTime
    {
        get { return this.totalTime; }
        set { this.totalTime = value; }
    }
    public string Name { get; private set; }
    public virtual double Speed => this.Car.Speed;

    public void IncreaseTotalTime(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    public void DecreaseFuelAmount(int trackLength)
    {
        this.Car.ChangeFuelAmount(-1 * trackLength * this.FuelConsumptionPerKm);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.totalTime:F3}";
    }
}