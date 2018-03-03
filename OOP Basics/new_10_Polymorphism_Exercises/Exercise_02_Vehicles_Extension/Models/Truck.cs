using System;

public class Truck : Vehicle
{
    private const double consumptionModifier = 1.6;
    private const double quantityModifier = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override double FuelConsumption
    {
        get
        {
            return base.FuelConsumption;
        }

        protected set
        {
            base.FuelConsumption = value + consumptionModifier;
        }
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException(
                $"Fuel must be a positive number");
        }
        if (liters * quantityModifier + base.FuelQuantity > base.tankCapacity)
        {
            throw new ArgumentException(
                $"Cannot fit {liters} fuel in the tank");
        }
        base.FuelQuantity += liters * quantityModifier;
    }
}