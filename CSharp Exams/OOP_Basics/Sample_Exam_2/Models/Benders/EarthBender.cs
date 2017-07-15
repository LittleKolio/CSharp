using System;

public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation) 
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; set; }

    public override double TotalPower()
    {
        return base.Power * this.GroundSaturation;
    }
    public override string ToString()
    {
        return $"Earth Bender: {base.Name}, Power: {base.Power}, Ground Saturation: {this.GroundSaturation:F2}";
    }
}
