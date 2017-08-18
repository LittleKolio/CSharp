namespace RecyclingStation.Models.Garbage
{
    using GarbageStrategy;
    using RecyclingStation.Models.Attributes;

    [Storable(typeof(StorableStrategy))]
    public class Storable : Garbage
    {
        public Storable(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
