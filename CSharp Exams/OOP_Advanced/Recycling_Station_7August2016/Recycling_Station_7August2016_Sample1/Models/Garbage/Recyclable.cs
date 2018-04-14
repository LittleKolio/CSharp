namespace RecyclingStation.Models.Garbage
{
    using GarbageStrategy;
    using RecyclingStation.Models.Attributes;

    [Recyclable(typeof(RecyclableStrategy))]
    public class Recyclable : Garbage
    {
        public Recyclable(string name, double weight, double volumePerKg)
            : base(name, weight, volumePerKg)
        {
        }
    }
}
