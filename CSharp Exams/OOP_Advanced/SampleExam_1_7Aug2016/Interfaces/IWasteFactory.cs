namespace RecyclingStation.Interfaces
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public interface IWasteFactory
    {
        IWaste GetWaste(string name, double weight, double volumePerKg, string type);
    }
}
