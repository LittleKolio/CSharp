using System;
using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    public PerformanceCar(
        string brand, 
        string model, 
        int yearOfProduction, 
        int horsepower, 
        int acceliration, 
        int suspension, 
        int durability) 
        : base(brand, model, yearOfProduction, acceliration, durability)
    {
        base.Horsepower = horsepower + (horsepower * 50) / 100;
        this.Suspension = suspension - (suspension * 25) / 100;
        this.AddOns = new List<string>();
    }

    public List<string> AddOns { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString() + Environment.NewLine);
        sb.Append("Add-ons: ");

        string addOns = "None";
        if (this.AddOns.Count > 0)
        {
            addOns = string.Join(", ", this.AddOns);
        }

        sb.AppendLine(addOns);

        return sb.ToString().TrimEnd();
    }
}