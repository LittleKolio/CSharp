using System;

public class Truck : Vehicle
{
    private const double consumptionModifier = 1.6;
    private const double quantityModifier = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption + consumptionModifier)
    {
    }

    public override void Refuel(double liters)
    {
        base.FuelQuantity += liters * quantityModifier;
    }
}