using System;

namespace Polymorphism_Exercises.Classes
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string region) 
            : base(name, weight, region) { }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                throw new ArgumentException(
                    $"Mouses are not eating that type of food!");
            }
            base.Eat(food);
        }
        public override string MakeSound()
        {
            return "SQUEEEAAAK!";
        }
    }
}
