namespace Polymorphism_Exercises.Classes
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Type = this.GetType().Name;
            this.Name = name;
            this.Weight = weight;
        }
        protected string Name { get; set; }
        protected string Type { get; set; }
        protected double Weight { get; set; }
        protected int FoodEaten { get; set; }

        public abstract string MakeSound();
        public virtual void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }
    }
}
