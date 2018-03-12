public abstract class Mode
{
    public Mode(string name, double enReqModifier, double oreOutModifier)
    {
        this.Name = name;
        this.EnReqModifier = enReqModifier;
        this.OreOutModifier = oreOutModifier;
    }

    public string Name { get; set; }
    public double EnReqModifier { get; set; }
    public double OreOutModifier { get; set; }
}