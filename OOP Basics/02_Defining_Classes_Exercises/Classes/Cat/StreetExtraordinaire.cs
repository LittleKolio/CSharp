namespace Defining_Classes_Exercises
{
    public class StreetExtraordinaire : Cat
    {
        public int DecibelsOfMeows { get; private set; }
        public StreetExtraordinaire(string name, int decibelsOfMeows) 
            : base (name)
        {
            this.DecibelsOfMeows = decibelsOfMeows;
        }
        public override string ToString()
        {
            return $"StreetExtraordinaire {this.Name} {this.DecibelsOfMeows}";
        }
    }
}
