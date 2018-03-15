public abstract class Driver
{
    protected Driver(string name, Car car)
    {
        this.name = name;
        this.Car = car;
    }

    protected double fuelConsumptionPerKm;
    private string name;
    private double totalTime;


    public Car Car { get; private set; }
    public double TotalTime
    {
        get { return this.totalTime; }
        set { this.totalTime = value; }
    }
    public string Name => this.name;
    public virtual double Speed => this.Car.Speed;

    public void IncreaseTotalTime(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    public void DecreaseFuelAmount(int trackLength)
    {
        this.Car.FuelAmount -= trackLength * this.fuelConsumptionPerKm;
    }

    public override string ToString()
    {
        return $"{this.name} {this.totalTime}";
    }
}