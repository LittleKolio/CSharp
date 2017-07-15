using System.Collections.Generic;
using System.Text;

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
                horsepower,
                acceleration, 
                suspension,
                durability)
    {
        this.ModifyStats();
        this.addOns = new List<string>();
    }

    private void ModifyStats()
    {
        base.Horsepower = base.Horsepower * 
            (Constants.CAR_HORSEPOWER_MODIFIER + 100) / 
            Constants.MAXIMUM_PERCENTAGE;
        base.Suspension = base.Suspension * 
            Constants.CAR_SUSPENTION_MODIFIER /
            Constants.MAXIMUM_PERCENTAGE;
    }

    public override void Tune(int index, string addOn)
    {
        base.Tune(index, addOn);
        this.addOns.Add(addOn);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());
        string addOns = this.addOns.Count > 0
            ? string.Join(", ", this.addOns)
            : "None";
        sb.Append($"Add-ons: {addOns}");
        return sb.ToString();
    }
}
