namespace RecyclingStation.Models
{
    using System;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class ProcessingData : IProcessingData
    {
        private double energyBalance;
        private double capitalBalance;

        public ProcessingData(double capitalBalance, double energyBalance)
        {
            this.CapitalBalance = capitalBalance;
            this.EnergyBalance = energyBalance;
        }

        public double CapitalBalance
        {
            get { return this.capitalBalance; }
            private set { this.capitalBalance = value; }
        }

        public double EnergyBalance
        {
            get { return this.energyBalance; }
            private set { this.energyBalance = value; }
        }
    }
}
