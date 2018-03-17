using System;

public abstract class Driver
{
    protected Driver(string name, double fuelConsumptionPerKm, Car car)
    {
        this.Name = name;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.Car = car;
        this.isRasing = true;
    }

    private string failure;

    public bool isRasing { get; private set; }
    public double FuelConsumptionPerKm { get; }
    public Car Car { get; }
    public double TotalTime { get; set; }
    public string Name { get; private set; }
    public virtual double Speed => this.Car.Speed;

    public void IncreaseTotalTime(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    public void DecreaseCarFuelAmount(int trackLength)
    {
        if (!this.isRasing)
        {
            return;
        }

        try
        {
            this.Car.ChangeFuelAmount(-1 * trackLength * this.FuelConsumptionPerKm);
        }
        catch (Exception ex)
        {
            this.failure = ex.Message;
            this.isRasing = false;
        }
    }

    public void DecreaseTyreDegradation()
    {
        if (!this.isRasing)
        {
            return;
        }

        try
        {
            this.Car.Tyre.DecreaseDegradation();
        }
        catch (Exception ex)
        {
            this.failure = ex.Message;
            this.isRasing = false;
        }
    }

    public void Crashed()
    {
        this.failure = "Crashed";
        this.isRasing = false;
    }

    public override string ToString()
    {

        return this.isRasing 
            ? $"{this.Name} {this.TotalTime:F3}" 
            : $"{this.Name} {this.failure}";
    }
}