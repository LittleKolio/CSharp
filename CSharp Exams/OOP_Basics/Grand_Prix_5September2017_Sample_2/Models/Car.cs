using System;

public class Car
{
    private const double tankMaxCapacity = 160;
    private const double tankMinCapacity = 0;

    public Car(int horsepower, double fuelAmount, Tyre tyre)
    {
        this.Horsepower = horsepower;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Horsepower { get; private set; }

    private double fuelAmount;
    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set
        {
            if (value < tankMinCapacity)
            {
                throw new Exception("Out of fuel");
            }
            if (value > tankMaxCapacity)
            {
                this.fuelAmount = tankMaxCapacity;
                return;
            }
            this.fuelAmount = value;
        }
    }

    public Tyre Tyre { get; set; }

}