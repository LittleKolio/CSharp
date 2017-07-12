using System.Collections.Generic;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(
        string brand, 
        string model, 
        int yearOfProduction, 
        int horsepower, 
        int acceleration, 
        int suspension, 
        int durability) 
        : base(
                brand, 
                model, 
                yearOfProduction, 
                horsepower * 150 / 100,
                acceleration, 
                suspension * 75 / 100,
                durability)
    {
        this.addOns = new List<string>();
    }

    public override string ToString()
    {
        string addOns = this.addOns.Count > 0
            ? string.Join(", ", this.addOns)
            : "None";
        return base.ToString() + $"Add-ons: {addOns}";
    }
}
