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

        private double minCapitalBalance;
        private double minEnergyBalance;
        private string requirmentsOfType;
        private bool setRequirments;

        public RecyclingManager(IGarbageProcessor processor, IWasteFactory factory)
        {
            this.processor = processor;
            this.factory = factory;
            this.setRequirments = false;
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            bool requirments = this.setRequirments && this.requirmentsOfType == type;

            if (requirments)
            {
                bool validBalance =
                    this.capitalBalance >= this.minCapitalBalance &&
                    this.energyBalance >= this.minEnergyBalance;

                if (!validBalance)
                {
                    return "Processing Denied!";
                }
            }

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

        public string ChangeManagementRequirement(double inputCapBalance, double inputEnBalance, string type)
        {
            this.minCapitalBalance = inputCapBalance;
            this.minEnergyBalance = inputEnBalance;
            this.requirmentsOfType = type;
            this.setRequirments = true;

            return "Management requirement changed!";
        }
    }
}
