namespace RecyclingStation.Models.Garbage
{
    public class Storable : Garbage
    {
        public Storable(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
