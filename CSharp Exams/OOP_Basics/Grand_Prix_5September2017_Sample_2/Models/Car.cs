using System;

public class Car
{
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
        => (this.Horsepower + this.Tyre.Degradation) / this.FuelAmount;
}