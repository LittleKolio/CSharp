using System;

public class BulletproofVest : Ammunition
{
    public const double BulletproofVestWeight = 3.4;

    public BulletproofVest(string name)
        : base(name)
    {
    }

    public override double Weight
    {
        get { return BulletproofVestWeight; }
    }
}