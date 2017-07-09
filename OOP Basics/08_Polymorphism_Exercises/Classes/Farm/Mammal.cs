namespace Polymorphism_Exercises.Classes
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string region) 
            : base(name, weight)
        {
            this.Region = region;
        }

        protected string Region { get; set; }
        public override string ToString()
        {
            return $"{base.GetType().Name}[{base.Name}, {base.Weight}, {this.Region}, {base.FoodEaten}]";
        }
    }
}
