using System;

public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity) 
        : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity { get; set; }

    public override int Bonus()
    {
        return this.AirAffinity;
    }
}
