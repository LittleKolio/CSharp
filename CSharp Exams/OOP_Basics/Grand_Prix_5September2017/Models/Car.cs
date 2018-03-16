using System;

public class Car
{
    public Car(int horsepower, double fuelAmount, Tyre tyre)
    {
        this.Horsepower = horsepower;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Horsepower { get;}
    private double fuelAmount;

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new Exception("Out of fuel");
            }

            this.fuelAmount = Math.Min(value, 160);
        }
    }

    public Tyre Tyre { get; set; }

    public virtual double Speed
        => (this.Horsepower + this.Tyre.Degradation) / this.FuelAmount;

    public void ChangeFuelAmount(double amount)
    {
        this.FuelAmount += amount;
    }
}