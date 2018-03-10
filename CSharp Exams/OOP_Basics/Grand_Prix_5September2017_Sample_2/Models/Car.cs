using System;

public class Car
{
    private const double tankMaxCapacity = 160;
    private const double tankMinCapacity = 0;

    public Car(int horsepower, double fuelAmount, Tyre tyre)
    {
        this.Hp = horsepower;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; set; }

    private double fuelAmount;
    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set
        {
            if (value < tankMinCapacity)
            {
                throw new ArgumentException();
            }
            if (value > tankMaxCapacity)
            {
                this.FuelAmount = tankMaxCapacity;
                return;
            }
            this.FuelAmount = value;
        }
    }

    public Tyre Tyre { get; set; }
}