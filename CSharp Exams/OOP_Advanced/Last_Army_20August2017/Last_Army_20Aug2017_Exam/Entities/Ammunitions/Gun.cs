using System;

public class Gun : Ammunition
{
    public const double GunWeight = 1.4;

    public Gun(string name)
        : base(name)
    {
    }

    public override double Weight
    {
        get { return GunWeight; }
    }
}