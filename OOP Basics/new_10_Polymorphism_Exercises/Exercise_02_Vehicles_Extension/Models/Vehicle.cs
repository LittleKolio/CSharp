using System;

public abstract class Vehicle : IVehicle
{
    protected readonly double tankCapacity;
    private double fuelQuantity;
    private double fuelConsumption;

    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.tankCapacity = tankCapacity;
        if (tankCapacity < fuelQuantity)
        {
            this.FuelQuantity = 0;
        }
        else
        {
            this.FuelQuantity = fuelQuantity;
        }
        this.FuelConsumption = fuelConsumption;
    }

    public virtual double FuelConsumption
    {
        get { return this.fuelConsumption; }
        protected set { this.fuelConsumption = value; }
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    $"{this.GetType().Name} needs refueling");
            }
            this.fuelQuantity = value;
        }
    }

    public void Drive(double distance)
    {
        this.FuelQuantity -= (distance * this.FuelConsumption);
    }

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException(
                $"Fuel must be a positive number");
        }
        if (liters + this.FuelQuantity > this.tankCapacity)
        {
            throw new ArgumentException(
                $"Cannot fit {liters} fuel in the tank");
        }
        this.FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}