using System;

public class Grenades : Ammunition
{
    public const double GrenadesWeight = 1.0;

    public Grenades(string name) 
        : base (name)
    {
    }

    public override double Weight
    {
        get { return GrenadesWeight; }
    }
}