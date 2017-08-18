namespace RecyclingStation.Models.GarbageStrategy
{
    using System;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class RecyclableStrategy : GarbageDisposalStrategy
    {
        protected override double CalcCapitalBalance(IWaste garbage)
        {
            double capitalEarned = 400 * garbage.Weight;
            return capitalEarned;
        }

        protected override double CalcEnergyBalance(IWaste garbage)
        {
            double energyProduced = 0;
            double energyUsed = 0.5 * WasteExtensionMethods.TotalVolume(garbage);

            return energyProduced - energyUsed;
        }
    }
}
