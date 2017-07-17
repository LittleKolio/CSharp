public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    { }

    public override double EnergyOutput
    {
        get { return base.EnergyOutput; }
        protected set
        {
            base.EnergyOutput = value +
                value *
                Constants.MODIFIER_PRESSUREPROVIDER_ENERGY /
                Constants.MAXIMUM_PERCENTAGE;
        }
    }
}
