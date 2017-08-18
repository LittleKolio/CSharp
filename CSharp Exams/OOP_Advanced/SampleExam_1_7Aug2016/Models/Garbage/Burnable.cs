namespace RecyclingStation.Models.Garbage
{
    using GarbageStrategy;
    using RecyclingStation.Models.Attributes;

    [Burnable(typeof(BurnableStrategy))]
    public class Burnable : Garbage
    {
        public Burnable(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
