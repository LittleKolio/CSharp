namespace RecyclingStation.Models.Garbage
{
    public class Recyclable : Garbage
    {
        public Recyclable(string name, double weight, double volumePerKg)
            : base(name, weight, volumePerKg)
        {
        }
    }
}
