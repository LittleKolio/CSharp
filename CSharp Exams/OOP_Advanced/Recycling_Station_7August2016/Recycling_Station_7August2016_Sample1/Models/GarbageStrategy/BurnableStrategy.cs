namespace RecyclingStation.Models.GarbageStrategy
{
    using System;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class BurnableStrategy : GarbageDisposalStrategy
    {
        protected override double CalcCapitalBalance(IWaste garbage)
        {
            return 0.0;
        }

        protected override double CalcEnergyBalance(IWaste garbage)
        {
            double totalVolume = WasteExtensionMethods.TotalVolume(garbage);
            double energyProduced = totalVolume;
            double energyUsed = 0.2 * totalVolume;

            return energyProduced - energyUsed;
        }
    }
}
