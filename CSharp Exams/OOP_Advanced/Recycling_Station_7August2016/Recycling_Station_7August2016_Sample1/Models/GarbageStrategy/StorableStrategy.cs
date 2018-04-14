namespace RecyclingStation.Models.GarbageStrategy
{
    using System;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class StorableStrategy : GarbageDisposalStrategy
    {
        protected override double CalcCapitalBalance(IWaste garbage)
        {
            double capitalEarned = 0;
            double capitalUsed = 0.65 * WasteExtensionMethods.TotalVolume(garbage);
            return capitalEarned - capitalUsed;
        }

        protected override double CalcEnergyBalance(IWaste garbage)
        {
            double energyProduced = 0;
            double energyUsed = 0.13 * WasteExtensionMethods.TotalVolume(garbage);

            return energyProduced - energyUsed;
        }
    }
}
