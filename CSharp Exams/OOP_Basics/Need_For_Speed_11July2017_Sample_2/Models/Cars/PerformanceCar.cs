using System.Collections.Generic;

public class PerformanceCar : Car
{
    public PerformanceCar(
        string brand, 
        string model, 
        int yearOfProduction, 
        int horsepower, 
        int acceliration, 
        int suspension, 
        int durability,
        IEnumerable<string> addOns) 
        : base(brand, model, yearOfProduction, horsepower, acceliration, suspension, durability)
    {
        this.AddOns = new List<string>(addOns);
    }

    public List<string> AddOns { get; private set; }
    public override int Horsepower
    {
        get => base.Horsepower;
        protected set => base.Horsepower = value + value / 2;
    }
    public override int Suspension
    {
        get => base.Suspension;
        protected set => base.Suspension = value - value / 4;
    }
}