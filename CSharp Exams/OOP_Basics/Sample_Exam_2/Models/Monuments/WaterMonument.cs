using System;

public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity) 
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity { get; set; }

    public override int Bonus()
    {
        return this.WaterAffinity;
    }
    public override string ToString()
    {
        return $"Water Monument: {base.Name}, Water Affinity: {this.WaterAffinity}";
    }
}