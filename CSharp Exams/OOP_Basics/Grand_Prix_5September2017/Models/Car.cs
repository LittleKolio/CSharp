using System;

public class Car
{
    public Car(int horsepower, double fuelAmount, Tyre tyre)
    {
        this.horsepower = horsepower;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    private int horsepower;
    private double fuelAmount;

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Out of fuel");
            }
            if (value > 160)
            {
                this.fuelAmount = 160;
                return;
            }
            this.fuelAmount = value;
        }
    }

    public Tyre Tyre { get; set; }

    public virtual double Speed
        => (this.horsepower + this.Tyre.Degradation) / this.FuelAmount;
}