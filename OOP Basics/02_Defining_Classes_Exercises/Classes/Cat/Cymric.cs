namespace Defining_Classes_Exercises.Classes
{
    class Cymric : Cat
    {
        private double furLength;
        public Cymric(string name, double furLength) : base(name)
        {
            this.furLength = furLength;
        }
        public override string ToString()
        {
            return $"Cymric {this.Name} {this.furLength:F2}";
        }
    }
}
