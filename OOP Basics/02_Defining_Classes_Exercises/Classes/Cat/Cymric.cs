namespace Defining_Classes_Exercises
{
    public class Cymric : Cat
    {
        public double FurLength { get; private set; }
        public Cymric(string name, double furLength) : base(name)
        {
            this.FurLength = furLength;
        }
        public override string ToString()
        {
            return $"Cymric {this.Name} {this.FurLength:F2}";
        }
    }
}
