using System.Collections.Generic;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
        base.foodList = new List<string> { "Vegetable", "Meat" };
        base.weightModifier = 0.3;
        base.sound = "Meow";
    }
}