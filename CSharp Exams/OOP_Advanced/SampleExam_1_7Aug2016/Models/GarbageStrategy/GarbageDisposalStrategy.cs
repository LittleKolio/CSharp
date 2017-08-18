namespace RecyclingStation.Models
{
    using System;
    using RecyclingStation.WasteDisposal.Interfaces;

    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        protected abstract double CalcCapitalBalance(IWaste garbage);
        protected abstract double CalcEnergyBalance(IWaste garbage);

        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            double capitalBalance = this.CalcCapitalBalance(garbage);
            double energyBalance = this.CalcEnergyBalance(garbage);

            return new ProcessingData(capitalBalance, energyBalance);
        }
    }
}
