using System;

public class Car : Vehicle
{
    private const double fuelModifier = 0.9;

    public Car(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption + fuelModifier)
    {
    }
}