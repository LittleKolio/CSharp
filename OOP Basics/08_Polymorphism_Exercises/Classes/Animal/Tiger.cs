using System;

namespace Polymorphism_Exercises.Classes
{
    public class Tiger : Female
    {
        public Tiger(string name, double weight, string region) 
            : base(name, weight, region) { }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new ArgumentException(
                    $"Tigers are not eating that type of food!");
            }
            base.Eat(food);
        }

        public override string MakeSound()
        {
            return "ROAAR!!!";
        }
    }
}
