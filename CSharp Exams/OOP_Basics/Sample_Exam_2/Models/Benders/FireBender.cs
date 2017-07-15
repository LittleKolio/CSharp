using System;

public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) 
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression { get; set; }

    public override double TotalPower()
    {
        return base.Power * this.HeatAggression;
    }
    public override string ToString()
    {
        return $"Fire Bender: {base.Name}, Power: {base.Power}, Heat Aggression: {this.HeatAggression:F2}";
    }
}
