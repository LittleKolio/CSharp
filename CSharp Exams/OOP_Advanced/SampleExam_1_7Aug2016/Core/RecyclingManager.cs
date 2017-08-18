namespace RecyclingStation.Core
{
    using System;
    using global::RecyclingStation.Interfaces;
    using WasteDisposal.Interfaces;

    public class RecyclingManager : IRecyclingManager
    {
        private IGarbageProcessor processor;
        private IWasteFactory factory;

        private double capitalBalance;
        private double energyBalance;

        public RecyclingManager(IGarbageProcessor processor, IWasteFactory factory)
        {
            this.processor = processor;
            this.factory = factory;
        }
        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            IWaste waste = this.factory.GetWaste(name, weight, volumePerKg, type);
            IProcessingData processedData = this.processor.ProcessWaste(waste);

            this.capitalBalance += processedData.CapitalBalance;
            this.energyBalance += processedData.EnergyBalance;

            return $"{waste.Weight:F2} kg of {waste.Name} successfully processed!";
        }

        public string Status()
        {
            return $"Energy: {this.energyBalance:F2} Capital: {this.capitalBalance:F2}";
        }
    }
}
