using System;

public class MachineGun : Ammunition
{
    public const double MachineGunWeight = 10.6;

    public MachineGun(string name)
        : base(name)
    {
    }

    public override double Weight
    {
        get { return MachineGunWeight; }
    }
}