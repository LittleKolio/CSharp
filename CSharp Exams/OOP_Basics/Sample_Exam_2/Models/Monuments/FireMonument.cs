using System;

public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) 
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity { get; set; }

    public override int Bonus()
    {
        return this.FireAffinity;
    }
    public override string ToString()
    {
        return $"Fire Monument: {base.Name}, Fire Affinity: {this.FireAffinity}";
    }
}
