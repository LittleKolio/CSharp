using System;

public class RPG : Ammunition
{
    public const double RPGWeight = 17.1;

    public RPG(string name)
        : base(name)
    {
    }

    public override double Weight
    {
        get { return RPGWeight; }
    }
}