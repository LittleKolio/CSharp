using System;

public class Shield : Ammunition
{
    public const double ShieldWeight = 3.7;

    public Shield(string name)
        : base(name)
    {
    }

    public override double Weight
    {
        get { return ShieldWeight; }
    }
}