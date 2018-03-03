using System.Collections.Generic;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
        base.foodList = new List<string> { "Vegetable", "Fruit" };
        base.weightModifier = 0.1;
        base.sound = "Squeak";
    }
}