using System;

public abstract class Vehicle : IVehicle
{
    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    private double fuelQuantity;
    private double fuelConsumption;

    public double FuelConsumption
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
        this.FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}