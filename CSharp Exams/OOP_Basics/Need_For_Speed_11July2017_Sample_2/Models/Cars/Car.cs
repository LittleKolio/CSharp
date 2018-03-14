using System;
using System.Text;

public abstract class Car
{
    public Car(
        string brand, 
        string model, 
        int yearOfProduction, 
        int horsepower, 
        int acceliration, 
        int suspension, 
        int durability)
        : this(brand, model, yearOfProduction, acceliration, durability)
    {
        this.Horsepower = horsepower;
        this.Suspension = suspension;
    }

    public Car(
    string brand,
    string model,
    int yearOfProduction,
    int acceliration,
    int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Acceleration = acceliration;
        this.Durability = durability;
    }


    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int YearOfProduction { get; private set; }
    public virtual int Horsepower { get; set; }
    public int Acceleration { get; private set; }
    public virtual int Suspension { get; set; }
    public int Durability { get; private set; }

    public double OverallPerformance => this.Horsepower / this.Acceleration + this.Suspension + this.Durability;
    public double EnginePerformance => this.Horsepower / this.Acceleration;
    public double SuspensionPerformance => this.Suspension + this.Durability;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s")
            .AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString().TrimEnd();
    }
}