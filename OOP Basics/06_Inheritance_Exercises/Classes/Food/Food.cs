namespace Inheritance_Exercises.Classes
{
    public abstract class Food
    {
        public Food(int happinessPoints)
        {
            this.HappinessPoints = happinessPoints;
        }
        public int HappinessPoints { get; private set; }
    }
}
