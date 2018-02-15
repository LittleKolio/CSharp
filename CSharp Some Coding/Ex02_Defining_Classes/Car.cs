using System;

public class Car
{
    private double fuel;

    public string Model { get; set; }
    public double Fuel
    {
        get { return this.fuel; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Insufficient fuel for the drive");
            }
            this.fuel = value;
        }
    }
    public double Consumption { get; set; }
    public double Distance { get; set; }

    public Car(string model, double fuel, double consumption)
    {
        this.Model = model;
        this.Fuel = fuel;
        this.Consumption = consumption;
        this.Distance = 0.0;
    }

    public void Drive(double dist)
    {
        this.Fuel -= (dist * this.Consumption);
        this.Distance += dist;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.Fuel:F2} {this.Distance}";
    }
}