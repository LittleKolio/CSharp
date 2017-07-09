namespace Inheritance_Exercises.Classes
{
    public class Mushrooms : Food
    {
        private const int HappinessPoints = -10;
        public Mushrooms() 
            : base(HappinessPoints) { }
    }
}
