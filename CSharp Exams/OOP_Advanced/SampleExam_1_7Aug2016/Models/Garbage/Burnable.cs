namespace RecyclingStation.Models.Garbage
{
    public class Burnable : Garbage
    {
        public Burnable(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
