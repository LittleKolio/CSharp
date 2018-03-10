using System;

public abstract class Car
{
    private const double tankCapacity = 160;
    private double fuelAmount;

    public int Hp { get; set; }
    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            if (value > tankCapacity)
            {
                this.FuelAmount = tankCapacity;
                return;
            }
            this.FuelAmount = value;
        }
    }
    public Tyre Tyre { get; set; }
}