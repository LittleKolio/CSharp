namespace RecyclingStation.WasteDisposal.Interfaces
{
    public static class WasteExtensionMethods
    {
        public static double TotalVolume(IWaste waste)
        {
            return waste.VolumePerKg * waste.Weight;
        }
    }
}
