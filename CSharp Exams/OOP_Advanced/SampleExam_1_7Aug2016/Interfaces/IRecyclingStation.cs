namespace RecyclingStation.Interfaces
{
    public interface IRecyclingStation
    {
        void ProcessGarbage(string name, double weight, double volumePerKg, string type);
        void Status();
    }
}
