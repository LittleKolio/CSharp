namespace RecyclingStation.Core
{
    using System;
    using global::RecyclingStation.Interfaces;
    using WasteDisposal.Interfaces;

    public class RecyclingManager : IRecyclingManager
    {
        private IGarbageProcessor processor;
        private IWasteFactory factory;

        public RecyclingManager(IGarbageProcessor processor, IWasteFactory factory)
        {
            this.processor = processor;
            this.factory = factory;
        }
        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            IWaste waste = this.factory.GetWaste(name, weight, volumePerKg, type);
            IProcessingData info = this.processor.ProcessWaste(waste);
            return "Test garbage";
        }

        public string Status()
        {
            return "Status";
        }
    }
}
