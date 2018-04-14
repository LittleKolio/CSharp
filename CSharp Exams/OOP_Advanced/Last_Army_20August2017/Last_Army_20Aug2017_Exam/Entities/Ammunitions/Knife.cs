using System;

public class Knife : Ammunition
{
    public const double KnifeWeight = 0.4;

    public Knife(string name)
        : base (name)
    {
    }

    public override double Weight
    {
        get { return KnifeWeight; }
    }
}