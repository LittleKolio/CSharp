using System;
using System.Text;

public class ShowCar : Car
{
    public ShowCar(
        string brand, 
        string model, 
        int yearOfProduction, 
        int horsepower, 
        int acceliration, 
        int suspension, 
        int durability) 
        : base(brand, model, yearOfProduction, horsepower, acceliration, suspension, durability)
    {
    }

    public int Stars { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString() + Environment.NewLine);
        sb.AppendLine($"{this.Stars} *");

        return sb.ToString().TrimEnd();
    }
}