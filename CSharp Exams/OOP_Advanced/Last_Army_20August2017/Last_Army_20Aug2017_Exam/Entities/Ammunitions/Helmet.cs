using System;

public class Helmet : Ammunition
{
    public const double HelmetWeight = 2.3;

    public Helmet(string name) 
        : base (name)
    {
    }

    public override double Weight
    {
        get { return HelmetWeight; }
    }
}