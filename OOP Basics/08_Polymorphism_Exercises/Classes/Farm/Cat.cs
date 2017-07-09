using System;

namespace Polymorphism_Exercises.Classes
{
    public class Cat : Female
    {
        public Cat(string name, double weight, string region, string breed) 
            : base(name, weight, region)
        {
            this.Breed = breed;
        }
        public string Breed { get; set; }

        public override string MakeSound()
        {
            return "Meowwww";
        }
        public override string ToString()
        {
            return $"{base.GetType().Name}[{base.Name}, {this.Breed}, {base.Weight}, {base.Region}, {base.FoodEaten}]";
        }
    }
}
