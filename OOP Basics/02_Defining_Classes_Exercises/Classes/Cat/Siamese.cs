namespace Defining_Classes_Exercises
{
    public class Siamese : Cat
    {
        public int EarSize { get; private set; }
        public Siamese(string name, int earSize) 
            : base(name)
        {
            this.EarSize = earSize;
        }
        public override string ToString()
        {
            return $"Siamese {this.Name} {this.EarSize}";
        }
    }
}
