using System.Collections.Generic;
using System.Linq;

namespace Inheritance_Exercises.Classes
{
    public class Gandalf
    {
        private List<Food> foodEaten;
        public Gandalf()
        {
            this.foodEaten = new List<Food>();
        }
        public void Eat(Food food)
        {
            this.foodEaten.Add(food);
        }

        public int GetHappinessPoints()
        {
            return this.foodEaten.Sum(f => f.HappinessPoints);
        }
    }
}
