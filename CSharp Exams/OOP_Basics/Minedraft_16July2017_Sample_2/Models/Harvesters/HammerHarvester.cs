﻿public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
    }

    public override double OreOutput
    {
        get { return base.OreOutput; }
        protected set { base.OreOutput = value * 3; }
    }

    public override double EnergyRequirement
    {
        get { return base.EnergyRequirement; }
        protected set { base.EnergyRequirement = value * 2; }
    }
}